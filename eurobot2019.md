
#CODE GUIDELINES

1) Code should look like a poem and be self-explanatory
2) Use functions
5) No magic constants in code
6) No pre-optimization, and more post-opt
7) Write specs --> write tests --> write code --> release



# PROTOCOL 2019
https://docs.google.com/spreadsheets/d/1j6GV8JzCToRLRh0yVEz2r-NNTBBeui3rUYlnIGAXVAA/edit#gid=1248994702


# General info
- Subscribers to the end of init

- no namespaces in init, all in launch

- For subscriber callback the last parameter is data from topic, for timer callback - event

- instead of paths like '/secondary_robot/stm_command', better do remap in launch file (using namespace)

- First list yaml-params, than publishers, and in the end - Subcribers
- Timer in the end, it should call function timer_callback, from which desireable methods are chosen


# ROBOT COMMUNICATION


    ssh odroid@192.168.88.239
    or
    secondary_robot
    
    ssh odroid@192.168.88.242
    or
    main_robot
    
    
    rosrun rqt_graph rqt_graph


### to ride using localisation

rostopic pub -1 /main_robot/navigation/command std_msgs/String "data: '1 move_line 0.4 0.4 0'"


### to ride by odometry

8 - vels
14 - pos

rotate:

    stm 1 8 0 0 2

    stm - topic
    1 - id
    8 - type of command
    0 - x
    0 - y
    2 - theta

move in X dir

    rostopic pub -1 /main_robot/stm/command std_msgs/String "data: '1 8 0.2 0 0'" 
    # or
    stm 1 8 0.2 0 0


Type commands like this using protocol commands (link above):

    stm 1 0x11


###VUSIALIZATION
on computer

    roslaunch eurobot_loc remote.launch
    roslaunch eurobot_loc visualization.launch

on robot

    roslaunch eurobot_loc pf_launch.launch

??
roslaunch eurobot multimaster.launch 

To check coords and delay

    rosrun tf tf_echo map secondary_robot

launch STM node

    roslaunch eurobot_stm STM_node.launch


###SIMULATION to collect chaos

    roslaunch eurobot_tactics tactics_sim.launch 
    rosrun eurobot_main imitate_cam.py -n 5
    rostopic pub -1 /secondary_robot/cmd_tactics std_msgs/String "data: 'abc collect_chaos'"



# WIRELESS PART SETUP

---------------
ifconfig

in /etc/network$ vim interfaces

add ip ros master

odroid@odroid:~$ cd /etc/
odroid@odroid:/etc$ sudo vim hosts





    # interfaces(5) file used by ifup(8) and ifdown(8)
    auto lo
    iface lo inet loopback
    auto wlan0
    auto eth0
    #allow-hotplug eth0
    iface eth0 inet static
            address 192.168.0.15
            netmask 255.255.255.0

smth

    ssh keygen
    enter
    enter enter
    copy id
    adress



# GIT

---------------

https://www.ohshitgit.com

http://rogerdudler.github.io/git-guide/

http://365git.tumblr.com/post/504140728/fast-forward-merge

http://rogerdudler.github.io/git-guide/

    git push --set-upstream upstream branch_name
    git config --global user.email nikolay.zherdev@gmail.com
    git config --global user.name "nickzherdev"

### create new repository

    cd eurobot2019_ws/
    git init
    
    
    git status
    git checkout branchname  # Change working branch
    git checkout -b your-branch # Create the branch on your local machine and switch in this branch
    git push -u upstream collect_chaos_pucks - in order for branch to watch origin
    
    git add filename
    git commit -m “Add chocolate.jpeg.”
    git push origin master (or git push upstream bt_chaos)
    
    git remote add origin (upstream) 
    git remote add upstream https://github.com/SkoltechRobotics/ros-eurobot-2019.git
    git remote add [name_of_your_remote] [name_of_your_new_branch]
    git commit
    
    git remote -v
    git push origin [name_of_your_new_branch] 
    
    git push upstream navnew
    git push upstream grab_atoms 
    
    git merge branchname (ex: loc)
    
    git push upstream navnew --force
    git push --set-upstream upstream test_nav_loc 

В том случае, если ветка master (или branch_name) не является отслеживаемой веткой origin/master (или origin/branch_name), а вы хотите сделать её таковой.

Выполнив команду git push -u origin master вы устанавливаете связь между той веткой, в которой вы находитесь и веткой master на удалённом сервере. Команду требуется выполнить единожды, чтобы потом можно было отправлять/принимать изменения лишь выполняя git push из ветки без указания всяких алиасов для сервера и удалённых веток. Это сделано для удобства.

    на роботе
    git clone https://github.com/SkoltechRobotics/ros-eurobot-2019.git
    
in case of problems with sertificates use this command

    git config --global http.sslverify false

copy file or folder from other branch

    git checkout branchname path/to/file/file.py
    git checkout collect_chaos_pucks eurobot_tactics/notebooks
    git checkout behavior_tree_backend eurobot_nav/scripts

To revert the previous commit (our merge commit), we do:

    git revert HEAD

To show last commits

    git reflog

To remove latest pull

    git reset --hard a0d3fe6, // where  a0d3fe6 - is a head id



# FILESYSTEM
--------------
transfer a file using sftp in UNIX

cd catkin_ws/src/ros-eurobot-2018/

/home/safoex/eurobot2019_ws/src/ros-eurobot-2019/eurobot_nav

~/eurobot2019_ws/src

rm -rf ros-eurobot-2019/ # recursevly delete folder and it's subfolders and files

- make file executable:

    chmod +x "filename"

- install new packages:

    sudo pip install --target=/usr/local/lib/python2.7/dist-packages shapely
    
    sudo pip install --target=/opt/ros/kinetic/lib/python2.7/dist-packages shapely

on odroid to show connected devices
    
    ls -l /dev/tty*


python arc_move_v01.py 

autostart ??? command
crontab -e
"""

To turn off odroid from ssh:

    sudo shutdown -h now

### free up memory on odroid
    rosclean purge


# make backup
- to show all connected devices use lsblk in terminal

- completely empty writable emmc through disk util
- to create IMAGE of all partitions
apt-get install pv
sudo dd if=/dev/sdf bs=1M | pv | dd of=/media/safoex/01D251799AF7F600/backup_eurobot_2101/backup.img
https://forum.odroid.com/viewtopic.php?f=52&t=22930

- to restore IMAGE on new emmc / sd_card
sudo dd if=/media/safoex/01D251799AF7F600/backup_eurobot_2101/backup.img of=/dev/sdf bs=1M


Error mounting /dev/sdf1 at /media/safoex/EurobotMain: Command-line `mount -t "ext4" -o "uhelper=udisks2,nodev,nosuid" "/dev/sdf1" "/media/safoex/EurobotMain"' exited with non-zero exit status 32: mount: wrong fs type, bad option, bad superblock on /dev/sdf1,
       missing codepage or helper program, or other error

       In some cases useful info is found in syslog - try
       dmesg | tail or so.alsfasfafkasfsafmsdklgnsdklmsdklmsklvmsdklvmklsa


    gedit ~/.bashrc 
    
    sudo vim /etc/hosts

## remove nesessity to enter password 
    sudo update-alternatives --config editor
    sudo visudo
    myuser ALL=(ALL) NOPASSWD:ALL



# DISPLAY with TKINTER

http://effbot.org/zone/tkinter-threads.htm

add in launch file when using display

    export DISPLAY=:0



# ROS WORKSPACE:
--------------

catkin workspace
http://wiki.ros.org/catkin/workspaces

Creating a ROS Package
http://wiki.ros.org/ROS/Tutorials/CreatingPackage
http://wiki.ros.org/ROS/Tutorials/catkin/CreatingPackage
http://wiki.ros.org/ROS/NetworkSetup

### create new node
catkin_create_pkg eurobot_display std_msgs rospy roscpp

### navigate to workspace/src to create a new package eurobot_core and eurobot_nav

cd ~/catkin_ws/src
mkdir ros-eurobot-2019
cd ros-eurobot-2019

mkdir scripts

    vim /etc/hosts 
    export PYTHONPATH="${PYTHONPATH}:/home/safoex/eurobot2019_ws/src/ros-eurobot-2019/libs"
    export PATH="${PATH}:/home/safoex/eurobot2019_ws/src/ros-eurobot-2019/scripts"
    
    export PYTHONPATH="${PYTHONPATH}:/home/odroid/catkin_ws/src/ros-eurobot-2019/libs"
    export PATH="${PATH}:/home/odroid/catkin_ws/src/ros-eurobot-2019/scripts"
    /home/odroid/catkin_ws/src/ros-eurobot-2019/libs


### Create new workspace
http://wiki.ros.org/catkin/Tutorials/create_a_workspace

    mkdir -p ~/eurobot2019_ws/src
    cd eurobot2019_ws/
    catkin_make
    source devel/setup.bash
    vim ~/.bashrc
    
    source ~/.bashrc 
    rosrun eurobot_tactics TacticsNode.py
    gedit ~/.bashrc 

In the header of each file we need to state which env to use! Otherwise it won't work!

    #!/usr/bin/env python


    rostopic echo /secondary_robot/stm/command 
    rostopic list 
    rosnode list
    
    rosnode kill /main_robot/particle_filter_node


# BT
- Action sets params - SET
- Condition node checks their status if callback activated - GET

- Three main parts: 
-- Dictionary
-- Callbacks
-- Nodes



### NO RVIZ IN LAUNCH FILE

    #! /bin/bash

    source /opt/ros/kinetic/setup.bash
    source ~/catkin_ws/devel/setup.bash



### setup laser_scan_matcher package:

    ros-laser-scan-matcher
    sudo apt-get install ros-kinetic-laser-scan-matcher
    roslaunch polar_scan_matcher demo.launch


# SYSTEMCTL - Autostart using SystemD service

Show journal with logs

    sudo journalctl -f -u main_start.service

Start / stop / restart service:

    sudo systemctl restart main_start
    sudo systemctl stop main_start
    sudo systemctl start main_start

Something:

    add ros-bashrc to service
    sudo systemctl status secondary_start.service   -  status of service
    sudo journalctl -f -u secondary_start.service   -  logs 


Alexey Kashapov and Mikhail Kurenkov set up SystemD service in our robots. 
Here is not complete instruction from internet:

To run this on boot you can create a simple systemd service. 
Create mavros.service file in /lib/systemd/system with the following contents:

[Unit]
Description=eurobot 

[Service]
Type=forking
ExecStart=/bin/bash -c "source /opt/ros/kinetic/setup.bash; /usr/bin/python /opt/ros/kinetic/bin/roslaunch mavros apm.launch"
Restart=on-failure

[Install]
WantedBy=multi-user.target
Then run:
sudo systemctl daemon-reload
And enable it on boot:
sudo systemctl enable mavros.service



# LOGs

    rosbag record -a
    cd ~/.ros/log/latest
    vim namefile.log



#TROOBLESHOOTING

### can't login your user in ubuntu
https://askubuntu.com/questions/223501/ubuntu-gets-stuck-in-a-login-loop

TL;DR, just try logging into the shell (Ctrl+Alt+F2 or whatever F between F1 and F6) and type

    sudo add-apt-repository ppa:graphics-drivers/ppa
    sudo apt update
    sudo apt install nvidia-367

If it succeeds, reboot.

    sudo reboot

### gui on odroid (mate panel)

    sudo mate-panel start

### free up memory on odroid
    rosclean purge

### Localization not working
- check if LIDAR is turned on (starts making noise) and connected to Ethernet port in Odroid
- check in RViz if robot is coreectly localized 
- we once experienced problem with receiving coordinates - Lidar was sending data, but on gui we saw only 0 0 0 - problem was with some drivers or kernel error in odroid. We then just changed odroid and all started working




# Workspace
Ctrl Alt 9 / 3 / 6 / 7 for sticking windows to different screen corners

tmuxinator new main_robot

https://github.com/tmuxinator/tmuxinator

with Ctrl+B start any coomand:

    shift+5 - vertically
    
    shift+" - horiz
    
    x - kill
    
    arrows - navigation
  
  


# Team

Жердев Николай
Пристанский Егор
Кашапов Алексей
Горбадей Никита
Хуан Эредиа
Эдгар Казиахмедов
Егоров Антон
Александр Соколовский
Лыхин Семен
Батыржан Алиханов

Михаил Куренков
Владимир Карандаев
Сергей Востриков
Евгений Сафронов
Тарас Мельник
Андрей Чемихин

Руководитель: Дмитрий Тетерюков


    Жердев Николай Алексеевич
    Александр Соколовский
    Лыхин Семен Александрович
    Горбадей Никита Петрович
    Хуан Эредиа
    Эдгар Казиахмедов
    Егоров Антон Андреевич
    Пристанский Егор Евгеньевич
    Кашапов Алексей Сергеевич
    Батыржан Алиханов


# TODO

    # class PucksSlave(object):
    #     def __init__(self):
    #         self.pucks = None
    #         self.mutex = threading.Lock()
    #         rospy.Subscriber("/pucks", MarkerArray, self.pucks_callback, queue_size=1)
    
    #     def pucks_callback(self, data):
    #         # rospy.loginfo("pucks callback, get")
    #         # rospy.loginfo(data)
    #         with self.mutex:
    #             self.pucks = data
    
    #     def get_pucks(self):
    #         with self.mutex:
    #             return self.pucks



# Something

cp -a .git .git-old2

git hash-object -w Cheatsheet.md

cp -r /home/odroid/catkin_ws/src/temporary-ros/ros-eurobot-2019/.git /home/odroid/catkin_ws/src/ros-eurobot-2019



It seems that your ~/.config/dconf/user* files are corrupted. Try the following command, it should recreate a new one and allow you to store your settings persistently:

mv ~/.config/dconf/ ~/.config/dconf.bak
Note that you may loose some customization that you may have set on your system as all of them will be reset.

If it does not solve your problem all you have to do is:

mv ~/.config/dconf.bak ~/.config/dconf/ 

