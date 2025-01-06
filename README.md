# Tasks

As a backend engineer at **Deadlock Developers**, your mission this sprint is to implement all necessary backend changes required to achieve sprint goals efficiently and ensure timely delivery—despite the occasional "deadlock." Stay sharp, code smarter than the bugs, and let’s prove our tagline wrong this time.

### FPDOM-0000 - Implement Best Solution Dialog to Display Top-Scoring Solution

Introduce a "Best Solution" dialog feature that displays the highest-scoring solution for a given exercise. This dialog will provide users with a quick and intuitive way to review the most optimal solution, helping them learn and improve their own approaches.

Functional Requirements:

The dialog should display the solution content & score. The dialog must be accessible from the exercise details page or similar context where users can view exercise submissions.
If no solutions exist for the exercise, the dialog should display an appropriate message to inform users.

### FPDOM-0001 - Ensure that only users with an active subscription can submit solutions for exercises.

Description:
Currently, there is no restriction in place to prevent users without an active subscription from submitting exercise solutions in the system. This feature aims to implement a subscription validation mechanism to ensure that only users with an active subscription can access the exercise submission functionality.


Before submitting an exercise solution, the system must verify if the user has an active subscription.
If the subscription is inactive or expired, prevent the submission and display an appropriate message.

Error Messaging: "Your subscription is not active. Please renew your subscription to submit exercises."

### FPDOM-0002 - to be continued, focus on service extraction