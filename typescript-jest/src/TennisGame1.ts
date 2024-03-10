import { TennisGame } from './TennisGame';

interface Player {
  name: string;
  score: number;
}

export class TennisGame1 implements TennisGame {
  private playerList: Player[] = []

  constructor(player1Name: string, player2Name: string) {
    this.playerList.push({name: player1Name, score: 0})
    this.playerList.push({name: player2Name, score: 0})
  }

  wonPoint(playerName: string): void {
    const player = this.playerList.find(_ => _.name === playerName)
    if (player) {
      player.score += 1
    }
  }

  getScore(): string {
    let score: string = '';
    let tempScore: number = 0;

    if (this.scoreIsEqual()) {
      switch (this.playerList[0].score) {
        case 0:
          score = 'Love-All';
          break;
        case 1:
          score = 'Fifteen-All';
          break;
        case 2:
          score = 'Thirty-All';
          break;
        default:
          score = 'Deuce';
          break;

      }
    } else if (this.playerList[0].score >= 4 || this.playerList[1].score >= 4) {
      const minusResult: number = this.playerList[0].score - this.playerList[1].score;
      if (minusResult === 1) score = 'Advantage player1';
      else if (minusResult === -1) score = 'Advantage player2';
      else if (minusResult >= 2) score = 'Win for player1';
      else score = 'Win for player2';
    }
    else {
      for (let i = 1; i < 3; i++) {
        if (i === 1) tempScore = this.playerList[0].score;
        else { score += '-'; tempScore = this.playerList[1].score; }
        switch (tempScore) {
          case 0:
            score += 'Love';
            break;
          case 1:
            score += 'Fifteen';
            break;
          case 2:
            score += 'Thirty';
            break;
          case 3:
            score += 'Forty';
            break;
        }
      }
    }
    return score;
  }

  private scoreIsEqual() {
    return this.playerList.reduce(
        (sameScore, player) =>
            player.score === sameScore ? sameScore : -1, this.playerList[0].score)
        > -1;
  }
}
