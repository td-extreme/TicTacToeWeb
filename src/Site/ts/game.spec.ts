/// <reference path="game.ts" />
import { expect } from 'chai';
import 'mocha';
import { Game } from './game'


describe('Game', () => {

    it('PlayerOne: Name is "One" and Mark is "X"', () => {
        let testGame = new Game();
        let expectedName = testGame.playerOneName;
        let expectedMark = testGame.playerOneMark;
        expect(testGame.playerOneName).to.equal(expectedName);
        expect(testGame.decodeMark(testGame.playerOneName)).to.equal(expectedMark);
    });

    it('PlayerOne: Name is "Two" and Mark is "O"', () => {
        let testGame = new Game();
        let expectedName = testGame.playerTwoName;
        let expectedMark = testGame.playerTwoMark;
        expect(testGame.playerTwoName).to.equal(expectedName);
        expect(testGame.decodeMark(testGame.playerTwoName)).to.equal(expectedMark);
    });

});