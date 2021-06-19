from tkinter import *
from tkinter import ttk
from tkinter import filedialog
import shutil
import os
import time
gui = Tk()
gui.geometry("600x400")
gui.title("File Check")
#importing the necessary modules and creating a window to hold the GUI

class FolderSelect(Frame):
    def __init__(self, parent = None, folderDescription = "", **kw):
        Frame.__init__(self, master = parent, **kw)
        self.folderPath = StringVar()
        #creating the labels, entry boxes, and button objects
        self.lblName = Label(self, text = folderDescription)
        self.lblName.grid(row = 0, column = 0, sticky = NW)
        self.entPath = Entry(self, textvariable = self.folderPath)
        self.entPath.grid(row = 1,column = 0)
        #naming the buttons and placing them on the grid
        self.btnFind = ttk.Button(self, text = "Folder Select", command = self.setFolderPath)
        self.btnFind.grid(row = 1,column = 2,sticky = NE)
    def setFolderPath(self):#getting the full file path of the selected folder
        folder_selected = filedialog.askdirectory()
        self.folderPath.set(folder_selected)
    @property
    def folder_path(self):
        return self.folderPath.get()

def RecentlyWorkedOn():
    #setting the necessary variables for the source folder, destination folder, time
    SFolder = SFolderSelect.folder_path
    DFolder = DFolderSelect.folder_path
    files = os.listdir(SFolder)
    SecsInDay = 86400
    now = time.time()
    earlier = now - SecsInDay
    for i in files:#the function that moves files from one folder to another if those files have been created or edited within the last 24 hours
        source_i = os.path.join(SFolder, i)
        if Last_Edited(source_i) > earlier:
            destination_i = os.path.join(DFolder, i)
            shutil.move(source_i, destination_i)
    
def Last_Edited(i):
        return os.path.getmtime(i)  

folderPath = StringVar()
#creating 2 instances of the labels and lacing them on the grid
SFolderSelect = FolderSelect(gui, "Source Folder")
SFolderSelect.grid(row = 0)

DFolderSelect = FolderSelect(gui, "Destination Folder")
DFolderSelect.grid(row = 1)
#creating the File Check button and giving it a function to run when pressed. Also creating the main loop that runs the Frame when the program is selected
c = ttk.Button(gui, text = "File Check", command = RecentlyWorkedOn)
c.grid(row = 4,column = 0)
gui.mainloop()
