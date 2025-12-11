Project title: CA_ONE — Part I (C#) & Part II (Python)
Author: Pooja Shree A N
Course: DBS — CA_ONE Assignment
Date: 11/12/2025

Overview

This repository contains solutions and supporting files for the CA_ONE assignment consisting of:

Part I — C#:

A console-based Phone Contact Book (menu-driven) implementing add/list/show/update/delete contacts using object-oriented design (Classes & Objects, Encapsulation, Properties, Access Modifiers, Method Overloading, Object Relationships). Minimum 20 contacts supported. Mobile number validation enforced.

A File Extension Info program: stores info for (≥20) file extensions and responds to user queries.

Part II — Python:
3. A Client-Server admissions application (client collects applicant info; server stores in a persistent database and returns a unique application number). Implemented using TCP (or UDP) with notes on security. Files: Que3_server.py, Que3_client.py.

A Web-scraping tool that extracts hotel room prices from two authorized sources, saves data to CSV and prints CSV contents. File: Que4_scraper.py (output hotels.csv).

Repository structure
/ (root)
├─ CSharp/
│  ├─ ContactBook/                # Solution for Question 1
│  │  ├─ ContactBook.sln
│  │  ├─ ContactBook/             # project
│  │  │  ├─ Program.cs
│  │  │  ├─ Contact.cs
│  │  │  ├─ ContactBookManager.cs
│  │  │  ├─ DataSeeder.cs
│  │  │  └─ README.md             # C# part README (short)
│  ├─ FileExtensions/             # Solution for Question 2
│  │  ├─ FileExtensions.sln
│  │  ├─ FileExtensions/          # project
│  │  │  ├─ Program.cs
│  │  │  ├─ ExtensionInfo.cs
│  │  │  └─ extensions.json       # list of ≥20 extensions & descriptions
│
├─ Python/
│  ├─ Que3_server.py              # Question 3 server
│  ├─ Que3_client.py              # Question 3 client
│  ├─ Que4_scraper.py             # Question 4 scraper
│  ├─ hotels.csv                  # sample/produced CSV (submit)
│  └─ requirements.txt
│
├─ README.md                      # this file
└─ LICENSE

Part I — C# (Details & How to run)
Q1: Phone Contact Book (ContactBook project)

Files

Contact.cs — Contact class representing a contact. Uses properties and encapsulation.

ContactBookManager.cs — maintains a collection of contacts (array/List). Implements add, list all, show detail, update, delete.

DataSeeder.cs — seeds at least 20 sample contacts on first run.

Program.cs — Main() implements menu-driven console UI.

Design highlights

Contact encapsulates fields (FirstName, LastName, Company, MobileNumber, Email, Birthdate).

ContactBookManager exposes methods:

AddContact(Contact c) (overloaded versions to accept raw fields or a Contact object),

GetAllContacts(),

GetContactById(int id) or GetContactByMobile(string mobile),

UpdateContact(int id, ...),

DeleteContact(int id).

Data structure: List<Contact> (flexible, allows easily holding ≥20 objects).

Validation:

Mobile number rule: must be a 9-digit positive integer and not zero-leading. (i.e., regex ^[1-9][0-9]{8}$). Any invalid input is rejected with user-friendly message and the application prompts again.

Email and birthdate validated with simple checks (email contains @ and .; birthdate parsed via DateTime.TryParse).

Persistence: basic solution is in-memory with seeded contacts (for assignment requirement). Optionally can be extended to file-based persistence (not required).

How to build & run (dotnet CLI)

Open a terminal and navigate to CSharp/ContactBook/.

Build:

dotnet build


Run:

dotnet run --project ContactBook


Use menu (numbers) to Add, Show All, Show Details, Update, Delete, Exit.

Sample menu

Main Menu
1: Add Contact
2: Show All Contacts
3: Show Contact Details
4: Update Contact
5: Delete Contact
0: Exit


Notes

The program seeds 20 sample contacts automatically (see DataSeeder.cs) to meet "min.20 contacts" requirement.

When updating, the program uses method overloading: UpdateContact(int id, Contact newData) and UpdateContact(int id, string field, string newValue).

Q2: File Extension Info (FileExtensions project)

Files

Program.cs — console UI to query extension info.

ExtensionInfo.cs — class that stores extension and description.

extensions.json — list of ≥20 extensions and descriptions (e.g., .mp4, .mov, .avi, .mkv, .webm, .mp3, .wav, .flac, .jpg, .png, .gif, .pdf, .docx, .xlsx, .pptx, .txt, .csv, .json, .xml, .html).

Behavior

Loads extensions.json at startup into an in-memory dictionary mapping extension → description.

Users can type an extension (with or without leading .). Program normalizes input and replies with info.

Graceful handling: unknown extensions return a friendly message like: Sorry — extension '.xyz' is not in my database.

How to run

cd CSharp/FileExtensions/

dotnet run --project FileExtensions

Part II — Python (Details & How to run)
Common setup

Python files use standard libraries and a few external libs for scraping & DB. Recommended to use a virtual environment.

Install dependencies

cd Python
python3 -m venv venv
source venv/bin/activate        # Linux/Mac
venv\Scripts\activate           # Windows

pip install -r requirements.txt


requirements.txt should include:

flask         # optional if server uses Flask for a simplified REST server
sqlite3       # included in stdlib; not in pip
requests
beautifulsoup4
lxml

Q3: Client-Server Admissions (Que3_server.py, Que3_client.py)

Overview

Client: console app that collects applicant information:

Name, Address, Educational qualifications, Desired course (one of 3), intended start year & month.

Server: receives data over a chosen protocol (TCP recommended), stores data persistently (SQLite database applications.db) and returns a unique application number.

Communication: simple request-response with JSON payload. Example flow:

Client sends JSON with applicant details.

Server stores the record and generates an application number (e.g., APP-20251211-0001).

Server responds with JSON containing status and application_number.

Files

Que3_server.py — listens on a port, handles incoming connections, validates & writes to SQLite, sends back application number.

Que3_client.py — collects input, sends to server, prints the server response (application number).

Database

Uses SQLite (sqlite3 module) — file-based relational DB, persistent on disk. Table structure example:

CREATE TABLE IF NOT EXISTS applications (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  app_number TEXT UNIQUE,
  name TEXT,
  address TEXT,
  qualifications TEXT,
  course TEXT,
  start_year INTEGER,
  start_month INTEGER,
  timestamp DATETIME DEFAULT CURRENT_TIMESTAMP
);


Unique application number

Format suggestion: APP-<YYYYMMDD>-<6-digit-seq> or APP-<timestamp>-<id>. Server ensures uniqueness.

Security considerations

The demo uses localhost for safety. For a production-like setup:

Use TLS/SSL (wrap socket with ssl).

Authenticate clients (API keys or mutual TLS).

Sanitize inputs (prevent injection) and parameterize DB queries (use ? placeholders).

Run server behind a firewall and validate IPs if necessary.

How to run (example using TCP)

Start server (in Python venv):

python Que3_server.py


Server will listen on 127.0.0.1:5000 (or configured host/port).

On same or different terminal, run client:

python Que3_client.py


Follow prompts. After submitting, client will display the application number returned by server.

Submission

Include Que3_server.py, Que3_client.py, and screenshots showing:

Server running and listening.

Client connecting and receiving an application number.

A view of the applications.db table (optional).

Q4: Hotel Price Scraper (Que4_scraper.py)

Requirements

Scrape two chosen hotel sources (must be explicitly allowed by the websites' terms — ensure the pages permit scraping).

Gather information for at least 10 rooms across the two establishments during the specified seasonal period (e.g., 20–30 December).

Store data in CSV, then read and print it at program end.

Files

Que4_scraper.py — main scraper. Uses requests + BeautifulSoup (or lxml) to fetch and parse pages.

hotels.csv — output file with columns such as:

source_hotel, room_name, occupancy, price, currency, date_for, extra_info, scraped_at, source_url