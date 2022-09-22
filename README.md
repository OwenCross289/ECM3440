# ECM3440

This project works with a soil moisture sensor emulator. It is part of our ECM3440 coursework.

## Rules
### Pushing to Main
- Nobody can push directly to main
- All code must pass through pull request
- GitHub action has to succeed
- Pull request branches must be up to date with master
- Pull request approvals will dismissed when new pushes are made to a pull request
- 2 people must approve a pull request
- All comments must be resolved

### Branching Rules
- All branches will start with 'ECM-'
- The number of the branch will be associated with the ticket of the story
- e.g. ECM-1

### Automated Pipelines
- Build runs on latest version of Ubuntu available on Github
- Build checks out and uses Python 3.10
- Build installs flake8 and pytest and resolves any requirements
- Build runs a flake8 analysis and runs pytests

## Team
- Owen Cross
- Devon Rockamore
- David Scott
- Jacob Enon
- Cameron Robinson