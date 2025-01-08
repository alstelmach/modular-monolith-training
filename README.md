# Tasks

As a backend engineer at **Deadlock Developers**, your mission this sprint is to implement all necessary backend changes required to achieve sprint goals efficiently and ensure timely delivery—despite the occasional "deadlock." Stay sharp, code smarter than the bugs, and let’s prove our tagline wrong this time.

### FPDOM-0000 - Prevent Adding New Solutions When a Reliable Solution Exists

Currently, the system allows users to add new solutions for an exercise even when a reliable solution already exists. A reliable solution is defined as one that has received at least 10 reviews, with each review rating being 8 or higher. This feature will ensure that no new solutions can be added in such cases to maintain quality and avoid redundant submissions.

Functional Requirements:

The system must check if a reliable solution exists before allowing the addition of new solutions.
A reliable solution must meet the following criteria:
At least 10 reviews.
All reviews must have a rating of 8 or higher.
If a reliable solution exists:
Prevent new solutions from being submitted.
Display an appropriate error message.

Error Messaging:
"Unable to submit a new solution. A reliable solution already exists for this exercise."

### FPDOM-0001 - Implement Best Solution Dialog to Display Top-Scoring Solution

Introduce a "Best Solution" dialog feature that displays the highest-scoring solution for a given exercise. This dialog will provide users with a quick and intuitive way to review the most optimal solution, helping them learn and improve their own approaches.

Functional Requirements:

The dialog should display the solution content & score. The dialog must be accessible from the exercise details page or similar context where users can view exercise submissions.
If no solutions exist for the exercise, the dialog should display an appropriate message to inform users.

### FPDOM-0002 - Ensure that only users with an active subscription can submit solutions for exercises.

Description:
Currently, there is no restriction in place to prevent users without an active subscription from submitting exercise solutions in the system. This feature aims to implement a subscription validation mechanism to ensure that only users with an active subscription can access the exercise submission functionality.

Before submitting an exercise solution, the system must verify if the user has an active subscription.
If the subscription is inactive or expired, prevent the submission and display an appropriate message.

Error Messaging: "Your subscription is not active. Please renew your subscription to submit exercises."

Hint: What about creating new module?


### FPDOM-0003 - Decouple Reviews Logic for Independent Releases

Currently, changes to the reviews logic are tied to the main release schedule, creating delays when updates or fixes are needed. This feature aims to decouple the reviews logic, allowing changes to be released independently of the broader release cycle. This will improve flexibility and speed in addressing bugs, implementing enhancements, and rolling out updates related to reviews.