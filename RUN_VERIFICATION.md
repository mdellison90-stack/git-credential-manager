# Git Credential Manager - Run Verification

This document verifies that Git Credential Manager can be successfully built and run.

## Environment

- **OS**: Linux (Ubuntu 24.04)
- **.NET SDK**: 10.0.102
- **Date**: 2026-02-16

## Verification Steps Completed

### 1. Dependency Restoration ✅

```bash
dotnet restore
```

**Result**: Successfully restored all project dependencies.

### 2. Build ✅

```bash
cd src/shared/Git-Credential-Manager
dotnet build
```

**Result**: Build succeeded with 0 warnings and 0 errors.

### 3. Run Application ✅

```bash
dotnet run --framework net8.0 -- --help
```

**Output**: Application displays help information correctly, showing all available commands:
- get
- store
- erase
- configure
- unconfigure
- diagnose
- azure-repos
- github

### 4. Version Check ✅

```bash
dotnet run --framework net8.0 -- --version
```

**Output**: `2.7.0+96293f4d5cf1500beaa6708b13078b913ceaefb1`

### 5. Test Suite ✅

```bash
dotnet test --no-restore
```

**Results**:
- **Total Tests**: 1,215
- **Passed**: 1,215
- **Failed**: 0
- **Skipped**: 49 (platform-specific tests)

**Test Projects**:
- Core.Tests: 799 passed, 44 skipped
- Atlassian.Bitbucket.Tests: 117 passed
- GitHub.Tests: 128 passed
- Microsoft.AzureRepos.Tests: 156 passed, 5 skipped
- GitLab.Tests: 15 passed

## Conclusion

Git Credential Manager successfully builds, runs, and passes all tests on the current platform.
All core functionality is operational.
