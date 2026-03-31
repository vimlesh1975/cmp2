# CMP Refactor Tracker

This file tracks module-by-module cleanup/refactor work so we can keep momentum without losing context.

## Status Key

- `Done`: refactor completed and kept
- `In Progress`: currently being worked on
- `Pending`: not started yet
- `Deferred`: intentionally postponed

## Completed

| Module | File | Status | Notes |
| --- | --- | --- | --- |
| `ucCG` | `CasparMediaPlayback/ucCG.vb` | Done | Logic refactored; visual redesign was reverted, original look kept. |
| `ucCG2` | `CasparMediaPlayback/ucCG2.vb` | Done | Logic refactored and duplication reduced. |
| `ucMixer` | `CasparMediaPlayback/ucMixer.vb` | Done | Mixer command sending, status reads, and XML save/load logic consolidated into shared helpers. |
| `ucMixernew` | `CasparMediaPlayback/ucMixernew.vb` | Done | Applied the same mixer helper consolidation as `ucMixer`, including XML settings and status-query cleanup. |
| `Form1` | `CasparMediaPlayback/Form1.vb` | Done | Composition element creation, playback, save/open, and loaded-media routing consolidated into reusable helpers. |
| `ucScroll` | `CasparMediaPlayback/ucScroll.vb` | Done | Scroll file I/O, row operations, selection toggles, color updates, and CG update helpers consolidated. |
| `ucBreakingNews` | `CasparMediaPlayback/ucBreakingNews.vb` | Done | Breaking-news file I/O, row operations, selection filters, and playback command helpers consolidated. |
| `ucTimers` | `CasparMediaPlayback/ucTimers.vb` | Done | Clock/timer template play, stop, clip-countdown update, and shared layer/template helpers consolidated. |

## Repository Cleanup

| Area | Status | Notes |
| --- | --- | --- |
| GitHub repo setup | Done | Project committed and pushed to `vimlesh1975/cmp2`. |
| Ignore rules | Done | Added ignores for `.vs`, `obj`, `.user`, logs, caches, and release output. |
| Release output tracking | Done | `CasparMediaPlayback/bin/x86/Release` removed from Git tracking. |
| Local dependency folder | Done | Added `CasparMediaPlayback/lib` and moved four project references off `bin/x86/Release`. |

## Next Suggested Modules

| Module | File | Status | Notes |
| --- | --- | --- | --- |
| `ucPlaylist` | `CasparMediaPlayback/ucPlaylist.vb` | Pending | Good candidate for shared helper extraction and cleanup. |
| `ucTemplate` | `CasparMediaPlayback/ucTemplate.vb` | Pending | Likely has similar template-play/update duplication worth centralizing. |
| `ucLogo` | `CasparMediaPlayback/ucLogo.vb` | Pending | Likely another compact graphics/control module suited to helper extraction. |
| `frmMediaPlayer` | `CasparMediaPlayback/frmMediaPlayer.vb` | Pending | Main shell; best handled after a few module-level refactors. |

## How To Update

When a module is refactored:

1. Move it to `Completed`
2. Add a short note about what changed
3. Keep `Next Suggested Modules` focused on the next 3-5 realistic targets
