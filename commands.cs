
/************* Git ****************/

// git fetch --prune
// Removes old branches from Git but does not delete them
// git branch -d "add-html-fo"
// 'branch -d' Will delete the branch from vscode


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


// Deletes branch so it does not appear in vscode.
// Note: Will need to close and reopen vscode.