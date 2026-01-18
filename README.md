☁️ MegaApp - Avalonia UI Desktop Client
A modern, fast, and simple MEGA.nz desktop client built with .NET 8 and Avalonia UI. This app allows you to manage your MEGA cloud storage with a sleek "pill-style" dark interface.

✨ Features
🔐 Secure Login – Connect to your MEGA account using official API protocols.
💾 Account Manager – Save multiple accounts locally for quick switching (one-click login).
📂 File Explorer – Browse your MEGA cloud files in a clean, card-based list.
📤 Easy Upload – Upload files from your local machine with a native file picker.
📥 Fast Download – Download files directly from the cloud to your computer.
📊 Progress Tracking – Real-time Progress Bar for all upload and download tasks.
🔄 Sync & Refresh – Update your file list manually with a dedicated refresh button.
🎨 Modern UI – Dark-themed, rounded "pill" design for a premium feel.

🛠️ Tech Stack
Technology	Usage
.NET 8	Core Framework
Avalonia UI	Cross-platform Desktop Toolkit
MegaApiClient	MEGA API Wrapper
System.Text.Json	Local Account Storage
C# Async/Await	Responsive UI & Background Tasks

🚀 Getting Started
Prerequisites
Download .NET 8 SDK
Quick Start (Development)
Navigate to the project folder:

cd ~/MegaApp

Restore and Run:

dotnet run

📦 Build & Installation (Linux)
To build a standalone executable and create a global command for your terminal:
1. Build the Release Version

dotnet publish -c Release -r linux-x64 --self-contained true
2. Set up the Terminal Alias
This allows you to launch the app by simply typing mega in your terminal.

# Add alias to your profile
echo "alias mega='~/MegaApp/bin/Release/net8.0/linux-x64/publish/MegaApp'" >> ~/.bashrc

# Refresh your terminal
source ~/.bashrc

3. Launch the App
mega
📖 How to Use

🔑 Login & Accounts
Enter your MEGA credentials and check "Remember Me" to save your account.
Your saved accounts will appear in the list at the bottom.
Click a saved account to auto-fill details, or Delete it using the red button.
📁 Managing Files

Upload: Click the green button to pick a file from your PC and send it to MEGA.
Download: Select a file from the list and click the blue button to save it locally.
Refresh: Use the top refresh button if your newly uploaded files don't appear immediately.
Logout: Click the top-right red button to safely switch accounts.
⚠️ Security Note

For simplicity, this application stores saved account credentials in plain text within accounts.json.
Only use the "Remember Me" feature on your private, trusted devices!

📜 Credits

Developed using Avalonia UI
Powered by MegaApiClient
Created for a smooth cloud management experience.
