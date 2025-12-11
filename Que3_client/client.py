import socket
import json

SERVER_HOST = "127.0.0.1"
SERVER_PORT = 6000
TOKEN = "application-secret"   # must match server token


def main():
    print("\n===== DBS Admission Application =====\n")

    name = input("Enter Name: ")
    address = input("Enter Address: ")
    qualifications = input("Enter Educational Qualifications: ")

    print("\nCourses:")
    print("1. MSc in Cyber Security")
    print("2. MSc Information Systems & computing")
    print("3. MSc Data Analytics")

    choice = input("Select course (1/2/3): ")

    if choice == "1":
        course = "MSc in Cyber Security"
    elif choice == "2":
        course = "MSc Information Systems & computing"
    elif choice == "3":
        course = "MSc Data Analytics"
    else:
        print("❌ Invalid choice")
        return

    start_year = input("Enter Start Year (YYYY): ")
    start_month = input("Enter Start Month (1-12): ")

    data = {
        "token": TOKEN,
        "name": name,
        "address": address,
        "qualifications": qualifications,
        "course": course,
        "start_year": start_year,
        "start_month": start_month
    }

    client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client.connect((SERVER_HOST, SERVER_PORT))

    client.send(json.dumps(data).encode())

    response = client.recv(4096).decode()
    response = json.loads(response)

    if response["status"] == "success":
        print("\n✅ Application Successful!")
        print("Your Application Number is:", response["application_number"])
    else:
        print("\n❌ Error:", response["message"])

    client.close()


if __name__ == "__main__":
    main()
