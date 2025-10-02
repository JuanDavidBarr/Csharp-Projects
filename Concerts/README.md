# 🎵 RiwiMusic Console Application

RiwiMusic is a **C# console-based music event management system** that allows users to manage concerts, register clients, sell tickets, and perform advanced queries using **LINQ**.

This project applies **Object-Oriented Programming (OOP)** principles to organize code logically and model real-world entities like concerts, clients, and tickets.

---

## 🔹Use case diagram: 
https://cdn.discordapp.com/attachments/1418340549483692215/1418822238442098728/image.png?ex=68d2d06e&is=68d17eee&hm=c490cf9fca2397ecbfc22729535ae244d187dd488f66f9d5432621f1f0813d3e

## 🔹UML diagram (class diagram)
https://cdn.discordapp.com/attachments/1418340549483692215/1418822410311827526/image.png?ex=68d2d097&is=68d17f17&hm=28c49b1d80be2d876b9ff1452d93ae80cd8a5cea5aa5a5df000b7a84eacaea54

## 📂 Project Structure

---

## ⚙️ Installation & Setup

### 🔹 Requirements
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher recommended)
- A terminal or IDE (Visual Studio, Rider, VS Code with C# extension)

### 🔹 Clone the Repository
```bash
git clone https://github.com/Voyager-team-BJ/Sprint-1-activity-5.git
cd riwi-music
dotnet run
```

---

# 🚀 Features

✅ Manage Concerts (Create, List, Update, Delete, View details)  
✅ Manage Clients (Register, Edit, Delete, List)  
✅ Manage Tickets (Sell, List, Edit, Delete)  
✅ Purchase History per Client  
✅ Advanced Queries using LINQ:  
- Concerts by city  
- Concerts by date range  
- Client with most purchases  
- Most popular concert  

---

# 🖥️ Usage Flow

When you run the program, you’ll see a main menu with options:  

- Manage Concerts 🎤  
- Manage Clients 👤  
- Manage Tickets 🎟️  
- Purchase History 📜  
- Advanced Queries 🔍  

Follow the menu prompts to navigate through different modules.  

### Example workflow:
- Add a new concert  
- Register a client  
- Sell a ticket for the client to attend the concert  
- View purchase history and run LINQ queries  

---

# 🧑‍💻 OOP Justification in RiwiMusic

For the RiwiMusic project, we applied **Object-Oriented Programming (OOP)** to structure the code in a more logical and real-world manner.  

### Identifying Entities as Classes
- Main entities: **Concert**, **Client**, and **Ticket**.  
- Each class acts as a blueprint grouping attributes and behaviors.  
- The **Ticket** class is crucial because it links a **Client** with a **Concert** via their IDs.  

### Encapsulation
- A central class **RiwiMusicSystem** stores all data collections (concerts, clients, tickets) as **private lists**.  
- Only **public methods** (e.g., `RegisterClient()`) can modify them.  
- This ensures **security and organization**, hiding internal complexity.  

### Abstraction
- The **Program.cs** file remains clean and only calls methods from `RiwiMusicSystem`.  
- The internal business logic is abstracted away from the main entry point.  

### Future Extensibility (Polymorphism & Inheritance)
- While inheritance wasn’t necessary in this version, polymorphism could easily be applied in the future (e.g., different ticket types such as **VIP** or **General** with different rules).  

📌 **In summary:**  
OOP allowed us to divide the project into clear modules, making the system organized, secure, and collaborative-friendly.  

---

# 🛠️ Technologies Used

- **C# 10 / .NET 8.0**  
- **LINQ** for advanced queries  
- **Console-based UI**  

---

# 🤝 Contributing

1. Fork the project  
2. Create a new feature branch (`git checkout -b feature/new-feature`)  
3. Commit your changes (`git commit -m 'Add new feature'`)  
4. Push the branch (`git push origin feature/new-feature`)  
5. Open a Pull Request 🎉  

---

# 📜 License

This project is licensed under the **MIT License**. You are free to use, modify, and distribute it.  

---

# ✨ Author

Developed with ❤️ by **Juan David Barrera and Brahiam Ruiz Alzate**
