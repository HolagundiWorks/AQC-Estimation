using Aorms.Bridge;
using AQCEstimation.Services;
using Microsoft.UI.Xaml;

namespace AQCEstimation;

public sealed partial class MainWindow : Window
{
    readonly AormsBridge _bridge;

    public MainWindow()
    {
        InitializeComponent();
        ExtendsContentIntoTitleBar = false;
        _bridge = AormsBridgeHost.CreateFromEnvironment();
        ApplyConnectLicenceStatus();
    }

    /// <summary>Licence SSO from AORMS Connect — never Activate here.</summary>
    void ApplyConnectLicenceStatus()
    {
        _bridge.TryImportConnectSession(overwrite: true);
        var cfg = _bridge.HubConfigured();
        RefreshStatus(
            cfg.HasSyncToken
                ? $"Licence from Connect · {cfg.HubUrl}"
                : "Unbound — Activate licence in AORMS Connect, then Re-import.");
    }

    void RefreshStatus(string? note = null)
    {
        var cfg = _bridge.HubConfigured();
        HubStatusText.Text =
            $"hub={cfg.HubUrl}  licenseApi={cfg.LicenseApiUrl}\n" +
            $"hasSyncToken={cfg.HasSyncToken}  syncReady={cfg.SyncReady}\n" +
            $"session={ConnectSession.DefaultPath()}";
        if (!string.IsNullOrWhiteSpace(note))
            LogText.Text = note;
    }

    void Refresh_Click(object sender, RoutedEventArgs e) => ApplyConnectLicenceStatus();

    void ReimportConnectSession_Click(object sender, RoutedEventArgs e)
    {
        var imported = _bridge.TryImportConnectSession(overwrite: true);
        ApplyConnectLicenceStatus();
        RefreshStatus(
            imported
                ? "Imported Connect session.json into AQC Estimation firm.db."
                : "No Connect session.json — Activate in AORMS Connect first.");
    }

    async void Flush_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            LogText.Text = "Flushing…";
            var result = await _bridge.FlushAsync();
            if (result.SkippedReason is not null)
                RefreshStatus($"Flush skipped={result.SkippedReason} — Activate in AORMS Connect first.");
            else
                RefreshStatus($"Flush OK metaSent={result.MetaSent} artSent={result.ArtifactsSent}");
        }
        catch (Exception ex)
        {
            RefreshStatus($"Flush failed: {ex.Message}");
        }
    }
}
