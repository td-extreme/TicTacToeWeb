/// <reference path="game.ts" />
import { expect } from 'chai';
import 'mocha';
import { Game } from './game'


describe('Game', () => {

    it('Game.decodeMark decode One to X and Two to O', () => {
        let testGame = new Game();
        expect(testGame.decodeMark("One")).to.equal("X");
        expect(testGame.decodeMark("Two")).to.equal("O");
    });

});