import csv

with open('serials.csv', 'r') as file:
    reader = csv.reader(file)

    with open('serials.sql', 'a') as sql_file:
        for row in reader:
            serial = row[0]  # Assumes each row contains one serial key
            sql_file.write(f"INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('{serial}', 0);\n")
