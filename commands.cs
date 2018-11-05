
/************* Git ****************/

// git fetch --prune
// Removes old branches from Git but does not delete them
// git branch -d "add-html-fo"
// 'branch -d' Will delete the branch from vscode
// Note: Will need to close and reopen vscode.


// You merge. That is actually quite simple, and a perfectly local operation:

// git checkout b1
// git merge master
// # repeat for b2 and b3
// This leaves the history exactly as it happened: You forked from master, you made changes to all branches, and finally you incorporated the changes from master into all three branches.

// git can handle this situation really well, it is designed for merges happening in all directions, at the same time. You can trust it be able to get all threads together correctly. It simply does not care whether branch b1 merges master, or master merges b1, the merge commit looks all the same to git. The only difference is, which branch ends up pointing to this merge commit.

// You rebase. People with an SVN, or similar background find this more intuitive. The commands are analogue to the merge case:

// git checkout b1
// git rebase master
// # repeat for b2 and b3

// In Terminal to update the branch with the master.
// 1) Switch to branch in vscode
// 2) In terminal: "git rebase master"

// Rebase will alter the history of when the branch was taken.
// I.e. If the branch was taken at "B" then rebase will change the logs to show the below
// A --- B --- C --- D <-- master
//                   \
//                    \-- E' --- F' --- G' <-- b1
//
// Merge on the other hand looks a more accurate log:
// A --- B --- C --- D <-- master
//  \
//   \-- E --- F --- G <-- b1
// The merge results in the true history:
//
// A --- B --- C --- D <-- master
//  \                 \
//   \-- E --- F --- G +-- H <-- b1

// https://stackoverflow.com/questions/5601931/best-and-safest-way-to-merge-a-git-branch-into-master
// So, when we suspect there would some conflicts, we can have following git operations:

// git checkout test
// git pull 
// git checkout master
// git pull
// git merge --no-ff --no-commit test


// PS C:\Users\Home\Documents\003 Development\GitHub\dev-learning> git rebase master
// First, rewinding head to replay your work on top of it...
// Fast-forwarded New-Learnings to master.
// PS C:\Users\Home\Documents\003 Development\GitHub\dev-learning> git log ..New-Learnings
// commit b745c4a04b55fa3f1764caee70da91ecd546d6ee (origin/New-Learnings, New-Learnings)
// Author: cbrewer <cluelessbrewer@gmail.com>
// Date:   Mon Nov 5 17:09:26 2018 +0000

//     Git merge and rebase code examples
// PS C:\Users\Home\Documents\003 Development\GitHub\dev-learning> git merge New-Learnings
// Updating 247ed1b..b745c4a
// Fast-forward
//  commands.cs | 42 ++++++++++++++++++++++++++++++++++++++++--
//  1 file changed, 40 insertions(+), 2 deletions(-)