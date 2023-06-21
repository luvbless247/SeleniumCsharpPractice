
Feature: Registration Page

A short summary of the feature

@Registration
Scenario Outline: Register new user
	Given I am on the home page
	When  I click on register
	Then registration page is displayed
	And  I click on sign up with email
	Then Sign up page is displayed
	And  I enter full name
	And I enter email 
	And  I enter password
	And I click on sign up button
	Then I should be register successfully
