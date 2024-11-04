# TFL Journey Planner 

This Solution automates the testing of the "Plan a journey" widget (Journey Planner) on the 
Transport for London (https://tfl.gov.uk/plan-a-journey) website using ReqNRoll, Playwright and  C#. 
The widget is accessible from the TfL homepage or by selecting the "Plan a journey" tab, 
and it allows users to input journey details and preferences to get optimized route suggestions.

# Getting Started

1.	Project Overview
2.	Features
3.	File Structure
4.	Running Tests

# Project Overview

This solution is focused on automating and validating the functionality of the **Journey Planner** widget. While TfL’s website includes a range of services and features, this project covers the Plan My Journey, which allows users to:

1. **Input an origin and destination** for a journey.
2. **Edit preferences** (e.g., routes with the least walking).
3. **View journey suggestions** with an estimated time based on the specified criteria.
4. **Validate the Journey results** with invalid Journey Planned.
5. **Validate the Journey** with no locations

By using this solution, we aim to ensure that the Journey Planner widget meets expected user functionality and provides accurate, preference-based results.

# Features

1. **JourneyPlanner.feature** - Cover the scenarios to Validate the journey  based on criteria
2. **JourneyPlannerNegative.feature** - Cover the scenarios to Validate the results with invalid data

## File Structure

- **`/Features`**: Contains feature files that define scenarios in Gherkin syntax.

- **`/Steps`**: Contains C# step definitions to execute the steps defined in feature files.

- **`/Common`**: Stores static constants (URLs, selectors, etc.) in `Constants.cs` to simplify maintenance and `startup.cs` adding the setting nd initializing the context and configuration's

- **`/Config`**: Configurations related to browser and Test

- **`/Pages`** Contains the implementation of the step definitions

  ![image-20241104033741489](C:\Users\my\AppData\Roaming\Typora\typora-user-images\image-20241104033741489.png)

  ## Running Tests
  
  To execute the tests,Open the Test Explorer and Run the Tests
  
  ![image-20241104034104415](C:\Users\my\AppData\Roaming\Typora\typora-user-images\image-20241104034104415.png)
