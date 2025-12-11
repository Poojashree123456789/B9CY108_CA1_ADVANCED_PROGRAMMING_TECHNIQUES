import requests
from bs4 import BeautifulSoup
import csv
from datetime import datetime
import re

headers = {
    "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"
}

# Reusable scraping function
def scrape_hotels(url):
    hotels = []
    response = requests.get(url, headers=headers)
    soup = BeautifulSoup(response.text, "html.parser")

    hotel_cards = soup.find_all("div", class_="hotel-card")
    for card in hotel_cards[:10]:

        name = card.find("div", class_="hotel-name")
        location = card.find("div", class_="hotel-location")
        desc = card.find("div", class_="hotel-description")
        price_tag = card.find("div", class_="current-price")

        if not (name and location and desc and price_tag):
            continue

        # Extract digits from price
        price_numbers = re.findall(r"\d+", price_tag.text)
        if not price_numbers:
            continue

        hotels.append({
            "Hotel": name.text.strip(),
            "Location": location.text.strip(),
            "Room_Type": desc.text.strip(),
            "Price_Per_Night": int(price_numbers[0]),
            "Currency": "EUR",
            "Date_Scraped": datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        })
    return hotels


# ----- SCRAPE BOTH SITES -----
all_hotels = []
all_hotels += scrape_hotels("https://booking-hotels2.tiiny.site/")
all_hotels += scrape_hotels("https://hotel1.tiiny.site/")

# ----- SAVE TO CSV -----
csv_filename = "hotel_prices_simple.csv"

with open(csv_filename, "w", newline="", encoding="utf-8") as f:
    writer = csv.DictWriter(f, fieldnames=[
        "Hotel", "Location", "Room_Type",
        "Price_Per_Night", "Currency", "Date_Scraped"
    ])
    writer.writeheader()
    writer.writerows(all_hotels)

print(f"Saved {len(all_hotels)} rows → {csv_filename}")

# ----- DISPLAY RESULTS -----
with open(csv_filename, "r", encoding="utf-8") as f:
    reader = csv.DictReader(f)
    for row in reader:
        print(f"{row['Hotel']} - €{row['Price_Per_Night']} - {row['Location']}")
