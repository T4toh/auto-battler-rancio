# Copilot Instructions

## Project Overview

Godot 4.6 auto-battler game using C# (.NET 8). The project is in early development — combat logic is not yet implemented.

## Build & Format

```sh
# Check compilation without Godot editor
dotnet build

# Format all C# files (CSharpier)
dotnet csharpier .

# Check formatting without applying changes
dotnet csharpier --check .
```

The game must be run from the Godot editor or via `godot --headless` — there is no standalone test suite.

## Architecture

The codebase is split into two clear layers:

- **`scripts/core/`** — Plain C# classes with no Godot dependency (`Character`, `Party`). These should remain Godot-agnostic.
- **`scripts/ui/`** — Godot `partial` node classes that own scene logic and wire up domain objects.
- **`scenes/main/`** — Root scene (`Main.tscn`).
- **`scenes/ui/`** — `.tscn` scene files that pair 1-to-1 with scripts in `scripts/ui/`.
- **`scenes/battle/`** — Placeholder for future battle unit scenes.

## Key Conventions

**Domain vs. UI separation**: Domain classes (`Character`, `Party`) are plain C# with no `partial` keyword and no Godot imports (`scripts/core/`). Keep game logic there. Only classes that extend Godot node types go in `scripts/ui/`.

**Partial classes for Godot nodes**: All classes that extend Godot types must be `partial`.

**Node wiring in `_Ready()`**: Child nodes are retrieved via `GetNode<T>("NodePath")` in `_Ready()`, not via `[Export]`. `[Export]` is reserved for scene references (e.g., `PackedScene`).

**Signals**: Godot signals use the delegate pattern:
```csharp
[Signal]
public delegate void CharacterSubmittedEventHandler(string name);
// Emit with:
EmitSignal(SignalName.CharacterSubmitted, name);
```

**File naming**: `.tscn` scene files use `snake_case`; `.cs` script files use `PascalCase`.

**Root namespace**: `autobattlerrancio` (set in `.csproj`).

**Damage formula**: `damage = Math.Max(1, attack - defense)` — minimum 1 damage always applies.
