## Ringo Media MVC & Mailing Service: Read Me

**Overview**

* This project is a backend system developed using ASP.NET Core MVC, Entity Framework Core, and MSSQL. 
* The primary focus is on functionality, utilizing the default template for UI elements. 
* The system includes modules for managing departments and sub-departments and a reminder module for email notifications.

**Modules**

1. Department/Sub-Departments Module
  * **Description:**
    
    * The Department/Sub-Departments module allows for managing departments and sub-departments with a multi-level hierarchy.

  * **Features:**

    * Departments can contain multiple sub-departments.
    * Sub-departments can further contain sub-departments, allowing for a nested hierarchy.
    * Functionality to select a department/sub-department and display:
    * A list of all sub-departments within the selected department/sub-department.
    * A list of all parent departments up to the top-level for the selected department/sub-department.
      
  * **Fields:**

    * Department Name: The name of the department.
    * Department Logo: The logo of the department.


2. Reminder Module
   
  * **Description:**
    * The Reminder module enables setting reminders that trigger email notifications.

  * **Features:**

    * Set reminders with a title and a specific date-time for sending an email notification.

  * **Fields:**
    * Title: The title of the reminder.
    * Date-Time: The date and time when the email notification should be sent.
