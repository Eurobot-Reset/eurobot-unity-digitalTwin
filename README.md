# Eurobot Unity 2020

### install this respository 

git clone https://github.com/Eurobot-Reset/eurobot-unity-digitalTwin.git

### to make new branch
```
git checkout -b BRANCH_NAME
```

### How to upload your work: Git push
```
git add . (to add all new files you've created or changed)
git commit -m "My message"  -- (for short commit)
git commit -s  -- (for detailed commit)

- (vim editor opens)
- i (to enter edit mode)


Subject: short overview

Continue the sentence "After pulling this commit I'll get...":
1) change 1
2) change 2
3) ...
```

To push from your local branch to the NEW remote one (and create the remote branch):

    git push -u origin localBranch:remoteBranchToBeCreated
    
To push from your local branch to already existing remote one:

    git push origin branchName
    
To pull the REMOTE branch you want to your LOCAL branch, where you are AT THE MOMENT:

    git pull origin remoteBrancNname

To revert the previous commit (our merge commit):

    git revert HEAD

To show last commits:

    git reflog

To remove latest pull:

    git reset --hard a0d3fe6, // where  a0d3fe6 - is a head id
