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

    if (this.isScoreEqual()) {
      score = this.getEqualScoreStr();
    } else if (this.isWin()) {
      const deltaResult = this.playerList[0].score - this.playerList[1].score;
      score = deltaResult > 0 ? 'Win for player1' : 'Win for player2'
    } else if (this.isMatchpoint()) {
      const deltaResult = this.playerList[0].score - this.playerList[1].score;
      score = deltaResult > 0 ? 'Advantage player1' : 'Advantage player2'
    }
    else {
      for (let i = 1; i < 3; i++) {
        if (i === 1) {
          tempScore = this.playerList[0].score;
        } else {
          score += '-';
          tempScore = this.playerList[1].score;
        }
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

  private isWin() {
    const deltaResult = Math.abs(this.playerList[0].score - this.playerList[1].score);
    return (this.playerList[0].score >= 4 || this.playerList[1].score >= 4) && deltaResult > 1;
  }

  private isMatchpoint() {
    const deltaResult = Math.abs(this.playerList[0].score - this.playerList[1].score);
    return (this.playerList[0].score >= 4 || this.playerList[1].score >= 4) && deltaResult == 1;
  }

  private getEqualScoreStr() {
    switch (this.playerList[0].score) {
      case 0:
        return 'Love-All';
      case 1:
        return 'Fifteen-All';
      case 2:
        return 'Thirty-All';
      default:
        return 'Deuce';
    }
  }

  private isScoreEqual() {
    return this.playerList[0].score === this.playerList[1].score
  }
}
