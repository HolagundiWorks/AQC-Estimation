# AQC Estimation

AORMS suite — Estimation desktop app (BOQ, rate books, measurement). Engine SoT: HolagundiWorks/AQC.

Part of the **AORMS** product suite ([aorms.in](https://aorms.in)).

| | |
| --- | --- |
| **Role** | Technical desktop installer |
| **Package id** | `in.aorms.aqc.estimation` |
| **Engine** | Shared `bbs_engine` + `Aorms.Bridge` from [AQC](https://github.com/HolagundiWorks/AQC) |
| **Hub** | [aorms](https://github.com/HolagundiWorks/aorms) — portals / Mongo ops |
| **Downloads** | [aorms.in/downloads](https://aorms.in/downloads) (signed installers when published) |

## Status

**S9:** Unpackaged WinUI shell + hub Activate/Flush (mirrors AStudio bridge host). Domain UI and MSIX packaging next. Do **not** fork a divergent calc engine — pin AQC tags.

## Develop

```bat
git submodule update --init --recursive
build-winui.cmd
```

Or:

```bat
"%ProgramFiles%\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" ^
  src\AQC-Estimation.csproj /p:Configuration=Release /p:Platform=x64 /restore
```

Set `ESTI_HUB_URL` (default `http://127.0.0.1:4000`) for local hub sync smoke tests.

## Suite map

- Managers: [AStudio](https://github.com/HolagundiWorks/AStudio) · [AConsulting](https://github.com/HolagundiWorks/AConsulting)
- Technical: [AQC-Estimation](https://github.com/HolagundiWorks/AQC-Estimation) · [AQC-BBS](https://github.com/HolagundiWorks/AQC-BBS) · [AQC-PM](https://github.com/HolagundiWorks/AQC-PM)
- Drafting: [AADT](https://github.com/HolagundiWorks/AADT) · [shilpidb](https://github.com/HolagundiWorks/shilpidb)
