import socket
import json
import sqlite3
import uuid
from datetime import datetime

HOST = "127.0.0.1"
PORT = 6000
TOKEN = "application-secret"


def create_db():
    conn = sqlite3.connect("db.sqlite")
    cur = conn.cursor()

    cur.execute("""
        CREATE TABLE IF NOT EXISTS applicants (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            app_number TEXT UNIQUE,
            name TEXT,
            address TEXT,
            qualifications TEXT,
            course TEXT,
            start_year INTEGER,
            start_month INTEGER,
            created_at TEXT
        )
    """)

    conn.commit()
    conn.close()


# -----------------------------
def generate_application_number():
    time_part = datetime.now().strftime("%Y%m%d%H%M%S")
    short_id = uuid.uuid4().hex[:5]
    return f"DBS-{time_part}-{short_id}"


# -----------------------------
def save_to_db(app_no, data):
    conn = sqlite3.connect("db.sqlite")
    cur = conn.cursor()

    cur.execute("""
        INSERT INTO applicants
        (app_number, name, address, qualifications, course, start_year, start_month, created_at)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?)
    """, (
        app_no,
        data["name"],
        data["address"],
        data["qualifications"],
        data["course"],
        int(data["start_year"]),
        int(data["start_month"]),
        datetime.now().isoformat()
    ))

    conn.commit()
    conn.close()


# -----------------------------
def validate_data(data):
    required = ["token", "name", "address", "qualifications",
                "course", "start_year", "start_month"]

    for item in required:
        if item not in data:
            return False, f"Missing field: {item}"

    if data["token"] != TOKEN:
        return False, "Invalid security token"

    return True, ""


# -----------------------------
def handle_client(client_socket):
    try:
        data = client_socket.recv(4096).decode()
        data = json.loads(data)

        valid, message = validate_data(data)
        if not valid:
            response = {"status": "error", "message": message}
            client_socket.send(json.dumps(response).encode())
            return

        app_no = generate_application_number()
        save_to_db(app_no, data)

        response = {
            "status": "success",
            "application_number": app_no
        }

        client_socket.send(json.dumps(response).encode())

    except Exception as e:
        response = {"status": "error", "message": str(e)}
        client_socket.send(json.dumps(response).encode())

    finally:
        client_socket.close()


# -----------------------------
def start_server():
    create_db()

    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.bind((HOST, PORT))
    server.listen(5)

    print("✅ Server running on port", PORT)

    while True:
        client_socket, addr = server.accept()
        print("🔗 Connection from", addr)
        handle_client(client_socket)


# -----------------------------
if __name__ == "__main__":
    start_server()
