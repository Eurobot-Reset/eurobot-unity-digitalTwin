# ros eurobot 2020

### Make new WorkSpace

http://wiki.ros.org/catkin/Tutorials/create_a_workspace

    mkdir -p ~/eurobot2020_ws/src
    cd eurobot2020_ws/
    catkin_make
    
    (only for current session)
    source ./devel/setup.bash

    (for all future sessions)
    vim ~/.bashrc
    source ~/eurobot2020_ws/src/devel/setup.bash

Than open new terminal and now roscd and roslaunch are available to use.

### install this respositoriy 
cd ~/eurobot2020_ws/src
git clone https://gitlab.com/skoltech-eurobot-team-2020/ros-eurobot-2020.git

### to make new branch
```
git checkout -b BRANCH_NAME
```

### Make new pkg 
```
cd ~/eurobot2020_ws/src/ros-eurobot-2020
catkin_create_pkg eurobot_{something} std_msgs rospy roscpp
```

### Git push
```
git add
git commit -m "My message"  -- for short commit
git commit -s  -- for detailed commit

- (vim editor opens)
- i (to enter edit mode)


Subject: short overview

Continue the sentence "After pulling this commit I'll get...":
1) change 1
2) change 2
3) ...


git push
```
