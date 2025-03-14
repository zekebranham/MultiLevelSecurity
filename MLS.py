import random

class User:
    def __init__(self, username, password, security_level):
        self.username = username
        self.password = password
        self.security_level = security_level

class File:
    def __init__(self, filename, security_level):
        self.filename = filename
        self.security_level = security_level

class System:
    def __init__(self):
        self.users = []
        self.files = []

    def add_user(self, username, password, security_level):
        self.users.append(User(username, password, security_level))

    def add_file(self, filename, security_level):
        self.files.append(File(filename, security_level))

    def authenticate(self, username, password):
        for user in self.users:
            if user.username == username and user.password == password:
                return user
        return None

    def display_accessible_files(self, user):
        accessible_files = [file.filename for file in self.files if file.security_level <= user.security_level]
        return accessible_files if accessible_files else ["No accessible files."]

def setup_system():
    sec_sys = System()
    sec_sys.add_user("alice", "iamAlice", 1)  # Public
    sec_sys.add_user("bob", "iamBob", 2)  # Limited
    sec_sys.add_user("kate", "iamKate", 3)  # Secret
    sec_sys.add_user("joe", "iamJoe", 4)  # Top Secret
    
    for i in range(1, 51):
        sec_sys.add_file(f"file_{i}.txt", random.randint(1, 4))
    
    return sec_sys

def main():
    sec_sys = setup_system()
    
    print("Welcome to Multi-Level Security System")
    username = input("Enter username: ")
    password = input("Enter password: ")
    
    user = sec_sys.authenticate(username, password)
    if user:
        print(f"\nLogin successful! Access level: {user.security_level}")
        print("Accessible files:")
        for file in sec_sys.display_accessible_files(user):
            print(f" - {file}")
    else:
        print("Invalid username or password.")

if __name__ == "__main__":
    main()

"""
Creds
    Public: alice, iamAlice
    Limited: bob, iamBob
    Secret: kate, iamKate
    Top-Secret: joe, iamJoe
"""
