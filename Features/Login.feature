
Feature: Login
As a user I should be able to login into the application 
with with valid credentials and should not be able to login with invalid credentials

 

@login
Scenario Outline: Login with username and password
	Given I am on the login page
	When  I enter "<username>" and "<password>"
	And I click on terms and conditions
	And I click on submit button
	Then I "<loginStatus>" be logged in successfully 

Examples: 
	  | username           | password    | loginStatus |
	  | rahulshettyacademy | learning    | should      |
	  | invalid_user1      | learning    | should not  |
	 



