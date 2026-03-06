import sys
import os
import pyvda

# get the command line target
if len(sys.argv) < 3:
    print("Usage: python swapDesktop.py <target desktop name> <target icon set>")
else:
    target = sys.argv[1]
    iconLayout = sys.argv[2]
    # Get a list of virtual desktops
    desktops = pyvda.get_virtual_desktops()

    for desktop in desktops:
        if desktop.name == target:
            desktop.go()
            os.system( "C:/Users/john/Desktop/ReIcon/ReIcon/ReIcon_x64.exe /Restore /ID "+iconLayout )
            break

# running this from the command line would be:
# conda run -n Desktops python swapDesktop.py <target desktop name> <target icon set>
# actual names / IDs for me here:
# conda run -n Desktops python C:/LocalData/Dev/Desktops/swapDesktop.py Home ulx
# conda run -n Desktops python C:/LocalData/Dev/Desktops/swapDesktop.py Dev ojl
# conda run -n Desktops python C:/LocalData/Dev/Desktops/swapDesktop.py Games gns
# conda run -n Desktops python C:/LocalData/Dev/Desktops/swapDesktop.py Music smv
# conda run -n Desktops python C:/LocalData/Dev/Desktops/swapDesktop.py Work ojl
# conda run -n Desktops python C:/LocalData/Dev/Desktops/swapDesktop.py CHess gns

# or using the batch file:

# swapDesktop.bat Home ulx
# et al

