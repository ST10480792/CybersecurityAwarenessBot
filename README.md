# Cybersecurity Awareness Chatbot – Part 2 (WPF GUI)

## Project Overview

The Cybersecurity Awareness Chatbot is a C# application developed using Windows Presentation Foundation (WPF) to educate South African citizens about cybersecurity awareness and online safety.

The chatbot provides users with cybersecurity guidance through an interactive graphical interface and natural conversation flow.

The chatbot helps users learn about cybersecurity topics such as:

* Password Safety
* Phishing
* Privacy
* Scams
* Safe Browsing
* Suspicious Links
* Malware
* General Cybersecurity Awareness

The chatbot interacts with users conversationally, remembers preferences, recognises user sentiment, and provides personalised cybersecurity guidance.

---

## Features

This chatbot includes the following features:

### Voice Greeting

* Plays a WAV audio greeting (`GreetingVoice.wav`) when the application launches.

### Graphical User Interface (WPF)

* User-friendly WPF interface
* Styled colours and spacing
* Interactive chat-based experience
* Cybersecurity-themed ASCII art

### Keyword Recognition

The chatbot recognises cybersecurity-related keywords and responds naturally to user questions.

Recognised topics include:

* Password Safety
* Phishing
* Privacy
* Scams
* Malware
* Safe Browsing
* Suspicious Links

Example:

User: `What is phishing?`

Chatbot: Provides phishing awareness tips.

---

### Random Responses

The chatbot randomly selects responses from stored collections to make conversations feel more natural and engaging.

Example:

User: `Tell me about phishing`

Chatbot: Provides one of multiple phishing safety tips.

---

### Conversation Flow

The chatbot remembers the last cybersecurity topic discussed and allows follow-up interactions such as:

* Tell me more
* Another tip
* Explain more

This creates a smoother and more natural conversation flow.

---

### Memory and Recall

The chatbot remembers user interests and personalises responses.

Example:

User:

`I like privacy`

Chatbot remembers the preference and recalls it later.

---

### Sentiment Detection

The chatbot recognises user emotions such as:

* Worried
* Curious
* Frustrated

It responds supportively while still providing cybersecurity advice.

Example:

User:

`I am worried about scams`

Chatbot reassures the user and provides safety tips.

---

### Input Validation and Error Handling

The chatbot gracefully handles unknown or unsupported input and avoids crashes.

Unknown inputs are handled using helpful chatbot responses.

---

## Technologies Used

* C#
* WPF (.NET Framework)
* Visual Studio
* GitHub
* GitHub Actions (CI)

---

## Project Structure

CybersecurityAwarenessBot/

│── CybersecurityAwarenessBot (Part 1 Console App)
│── CybersecurityAwarenessBot_Part2 (WPF Application)
│── README.md
│── .github/workflows
│── Media/
│   └── GreetingVoice.wav

---

## How to Run the Project

1. Open the solution in Visual Studio.
2. Build the solution.
3. Run the WPF chatbot application.
4. Enter your name when prompted.
5. Ask cybersecurity-related questions.

Example questions:

* What is phishing?
* Tell me about password safety
* I like privacy
* Tell me more
* Explain more
* I am worried about scams
* Tell me about malware
* What are suspicious links?

---

## Screenshots

### Chatbot GUI
<img width="1873" height="882" alt="GUI_Screenshot" src="https://github.com/user-attachments/assets/cec95f27-31c3-4109-ba7e-631fe605e21a" />



### Example Conversation
<img width="1882" height="851" alt="Conversation" src="https://github.com/user-attachments/assets/19319cd1-68d3-4059-a9aa-7758c820e264" />


### GitHub Actions Successful Run
<img width="1397" height="106" alt="GitHubActions" src="https://github.com/user-attachments/assets/4f31cae6-77a9-4568-9404-ff5d9eaf604b" />

---

## GitHub Releases

### v1.0

Initial WPF chatbot GUI and voice greeting implementation.

### v2.0

Added keyword recognition, random responses, and conversation flow.

### v3.0

Implemented memory, sentiment detection, and final chatbot improvements.

---

## Author

Developed for the Programming 2A Cybersecurity Awareness Chatbot POE.

Author: Lisakhanya
