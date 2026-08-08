// SPDX-License-Identifier: AGPL-3.0-or-later
// SPDX-FileCopyrightText: 2026 Human Centric Works, Hospet

using Aorms.Bridge;

namespace AQCEstimation.Services;

/// <summary>
/// Factory for the AORMS hub bridge (firm.db under LocalAppData\AQC-Estimation).
/// Imports AORMS Connect session.json when present (C2 SSO).
/// </summary>
public static class AormsBridgeHost
{
    public static AormsBridge CreateFromEnvironment()
    {
        var deviceId = Environment.GetEnvironmentVariable("INSTALL_ID")
            ?? $"aqc-estimation-{Environment.MachineName}".ToLowerInvariant();
        var opt = new BridgeOptions
        {
            LicenseApiUrl = Environment.GetEnvironmentVariable("ESTI_LICENSE_API_URL") ?? "",
            HubUrl = Environment.GetEnvironmentVariable("ESTI_HUB_URL") ?? "http://127.0.0.1:4000",
            ProductApiKey = Environment.GetEnvironmentVariable("ESTI_PRODUCT_API_KEY") ?? "",
            DeviceId = deviceId,
            DeviceName = "AQC Estimation",
        };
        var dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "AQC-Estimation",
            "firm.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);
        var bridge = new AormsBridge(opt, dbPath);
        // Connect session wins when present (suite SSO).
        bridge.TryImportConnectSession(overwrite: true);
        return bridge;
    }
}
