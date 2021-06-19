import shutil
import os
import time
import tkinter
from tkinter import *

class ParentWindow(Frame):
    #creating a window with Tkinter that will house my custom GUI
    def __init__ (self, master):
        Frame.__init__(self)
        
        self.master = master
        self.master.resizable(width=False, height=False)
        self.master.geometry('{}x{}'.format(1400, 400))
        self.master.title('File Sort Script')
        self.master.config(bg='lightgray')

        self.lblCustomText = Label(self.master, text = 'Select source Folder: ', font = ("Helvetica", 16), fg = 'black', bg = 'lightgray')
        self.lblCustomText.grid(row = 0, column = 0, padx = (30, 0), pady = (30, 0))

        self.lblCustomText = Label(self.master, text = 'Select destination Folder: ', font = ("Helvetica", 16), fg = 'black', bg = 'lightgray')
        self.lblCustomText.grid(row = 1, column = 0, padx = (30, 0), pady = (30, 0))

        self.SourceOptions = ["FolderA", "FolderB", "FolderC"]
        Source_Value = tkinter.StringVar(root)
        Source_Value.set("Select an Option")

        questionMenu = tkinter.OptionMenu(root, Source_Value, *self.SourceOptions)
        questionMenu.grid(row = 0, column = 3, padx = (30, 0), pady = (30, 0))

        self.DestinationOptions = ["FolderA", "FolderB", "FolderC"]
        Destination_Value = tkinter.StringVar(root)
        Destination_Value.set("Select an Option")

        questionMenu = tkinter.OptionMenu(root, Destination_Value, *self.DestinationOptions)
        questionMenu.grid(row = 1, column = 3, padx = (30, 0), pady = (30, 0))

        self.btnRun = tkinter.Button(self.master, text = "Run", width = 10, height = 2, command = self.run)
        self.btnRun.grid(row = 3, column = 1, padx = (0, 0), pady = (30, 0), sticky = NE)

        self.btnCancel = tkinter.Button(self.master, text = "Cancel", width = 10, height = 2, command = self.cancel)
        self.btnCancel.grid(row = 3, column = 3, padx = (0, 90), pady = (30, 0), sticky = NE)
            
        
    
        

    def Last_Edited(i):
        return os.path.getmtime(i)


    def run(self):


        if Source_Value.get() == "FolderA":
            source = 'C:/Users/Zizzle/Desktop/FolderA/'
        elif Source_Value.get() == "FolderB":
            source = 'C:/Users/Zizzle/Desktop/FolderB/'
        elif Source_Value.get() == "FolderC":
            source = 'C:/Users/Zizzle/Desktop/FolderC/'

        if Destination_Value.get() == "FolderA":
            destination = 'C:/Users/Zizzle/Desktop/FolderA/'
        elif Destination_Value.get() == "FolderB":
            destination = 'C:/Users/Zizzle/Desktop/FolderB/'
        elif Destination_Value.get() == "FolderC":
            destination = 'C:/Users/Zizzle/Desktop/FolderC/'
        
        files = os.listdir(source)
        for i in files:
            source_i = os.path.join(source, i)
            if Last_Edited(source_i) > earlier:
                destination_i = os.path.join(destination, i)
                shutil.move(source_i, destination_i)











                        
    def cancel(self):
        self.master.destroy()





        
        SecsInDay = 86400
        now = time.time()
        earlier = now - SecsInDay



        if Source_Value.get() == "FolderA":
            source = 'C:/Users/Zizzle/Desktop/FolderA/'
        elif Source_Value.get() == "FolderB":
            source = 'C:/Users/Zizzle/Desktop/FolderB/'
        elif Source_Value.get() == "FolderC":
            source = 'C:/Users/Zizzle/Desktop/FolderC/'

        if Destination_Value.get() == "FolderA":
            destination = 'C:/Users/Zizzle/Desktop/FolderA/'
        elif Destination_Value.get() == "FolderB":
            destination = 'C:/Users/Zizzle/Desktop/FolderB/'
        elif Destination_Value.get() == "FolderC":
            destination = 'C:/Users/Zizzle/Desktop/FolderC/'













            
if __name__ == "__main__":
    root = Tk()
    App = ParentWindow(root)
    root.mainloop()
