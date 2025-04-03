## Delegates, Events, and Basic Event Handling

## Objective

Build a console-based event-driven counter application that triggers an event upon reaching a threshold, demonstrating event-based decoupling between producer and consumer logic.

## Concepts Learned

Delegates are type-safe function pointers that refers to methods with a parameter list and return type, while Events are a specific type of delegate used for implementing publisher-subscriber patterns, enabling objects to notify others when something significant happens.
<br><br>
Steps to define and use delegates, events and event handlers:
<br>

1. Define a delegate.
   <br>
2. Define an event based on that delegate.
   <br>
3. Raise the event
   <br>
4. Define event handlers
   <br><br>

Decoupling : The event handler can be defined outside the class of event raisers handlers. The handlers can be added in the Main method class.
