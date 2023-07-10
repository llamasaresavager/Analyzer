
import tkinter as tk
from tkinter import ttk
from tkinter import filedialog
import json

class App:
    def __init__(self, root):
        self.root = root
        self.tree = ttk.Treeview(root)
        self.tree["columns"] = ("Name", "Type")
        self.tree.column("Name", width=200)
        self.tree.column("Type", width=100)
        self.tree.heading("Name", text="Name")
        self.tree.heading("Type", text="Type")
        self.tree.bind('<Button-1>', self.item_selected)
        self.tree.pack()
        
        self.save_button = tk.Button(root, text="Save", command=self.save)
        self.save_button.pack()

        self.load_json()

    def load_json(self):
        filename = filedialog.askopenfilename(filetypes=[('JSON Files', '*.json')])
        with open(filename) as f:
            self.data = json.load(f)
        
        self.populate_tree(self.data, "")

    def populate_tree(self, directory_data, parent):
        for subdirectory in directory_data['Subdirectories']:
            id = self.tree.insert(parent, "end", text=subdirectory['Name'], values=("Directory", True))
            self.populate_tree(subdirectory, id)

        for file in directory_data['Files']:
            self.tree.insert(parent, "end", text=file, values=("File", True))

    def item_selected(self, event):
        item = self.tree.identify_row(event.y)
        if item:
            is_selected = self.tree.item(item, "values")[1]
            self.tree.item(item, values=(self.tree.item(item, "values")[0], not is_selected))

    def save(self):
        filename = filedialog.asksaveasfilename(defaultextension=".json")
        with open(filename, 'w') as f:
            json.dump(self.data, f)

root = tk.Tk()
app = App(root)
root.mainloop()
