@Integration
Feature: POST Paste

User posts a Paste

Scenario: Creating a Paste
	When a POST request is sent to the Paste endpoint
	Then the response code is 201 (Created)