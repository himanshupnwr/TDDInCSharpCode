Feature: TickTacToe
	In order to play a tick tac toe game 
	As a gamer
	I want to be able to put crosses or noughts and determine a winner

A short summary of the feature

@tag1
Scenario: Play Game
	Given I started a new game
	When I put three crosses in a row
	Then I should win
