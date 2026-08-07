# AQC Estimation

AORMS suite — Estimation desktop app (BOQ, rate books, measurement). Engine SoT: HolagundiWorks/AQC.

Part of the **AORMS** product suite ([aorms.in](https://aorms.in)).

| | |
| --- | --- |
| **Role** | Technical desktop installer |
| **Engine** | Shared `bbs_engine` + `Aorms.Bridge` from [AQC](https://github.com/HolagundiWorks/AQC) |
| **Hub** | [aorms](https://github.com/HolagundiWorks/aorms) — portals / Mongo ops |
| **Downloads** | [aorms.in/downloads](https://aorms.in/downloads) (signed installers when published) |

## Status

Scaffold product shell. Domain UI and MSIX packaging land next. Do **not** fork a divergent calc engine — pin AQC tags.

## Develop

\\\at
git submodule update --init --recursive
dotnet run --project src\AQC-Estimation.csproj -c Release
\\\

Set `ESTI_HUB_URL` for local hub sync smoke tests.

## Suite map

- Managers: [AStudio](https://github.com/HolagundiWorks/AStudio) · [AConsulting](https://github.com/HolagundiWorks/AConsulting)
- Technical: [AQC-Estimation](https://github.com/HolagundiWorks/AQC-Estimation) · [AQC-BBS](https://github.com/HolagundiWorks/AQC-BBS) · [AQC-PM](https://github.com/HolagundiWorks/AQC-PM)
- Drafting: [AADT](https://github.com/HolagundiWorks/AADT) · [shilpidb](https://github.com/HolagundiWorks/shilpidb)
