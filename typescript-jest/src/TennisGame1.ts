import { TennisGame } from './TennisGame';

interface Player {
  name: string;
  score: number;
}

export class TennisGame1 implements TennisGame {
  private playerList: Player[] = [];

  constructor(player1Name: string, player2Name: string) {
    this.playerList.push({name: player1Name, score: 0});
    this.playerList.push({name: player2Name, score: 0});
  }

  wonPoint(playerName: string): void {
    const player = this.playerList.find(_ => _.name === playerName);
    if (player) {
      player.score += 1;
    }
  }

  getScore(): string {
    const deltaResult = this.playerList[0].score - this.playerList[1].score;

    if (this.isScoreEqual(deltaResult)) {
      return this.getEqualScoreStr();
    } else if (this.isWin(deltaResult)) {
      return deltaResult > 0 ? 'Win for player1' : 'Win for player2';
    } else if (this.isMatchPoint(deltaResult)) {
      return deltaResult > 0 ? 'Advantage player1' : 'Advantage player2';
    } else {
      return this.getCurrentScoreText();
    }
  }

  private isWin(deltaResult: number) {
    return (this.playerList[0].score >= 4 || this.playerList[1].score >= 4) && Math.abs(deltaResult) > 1;
  }

  private isMatchPoint(deltaResult: number) {
    return (this.playerList[0].score >= 4 || this.playerList[1].score >= 4) && Math.abs(deltaResult) == 1;
  }

  private isScoreEqual(deltaResult: number) {
    return deltaResult === 0;
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

  private getCurrentScoreText() {
    return this.getScoreText(this.playerList[0].score) + '-' + this.getScoreText(this.playerList[1].score);
  }

  private getScoreText(tempScore: number) {
    switch (tempScore) {
      case 0:
        return 'Love';
      case 1:
        return  'Fifteen';
      case 2:
        return  'Thirty';
      case 3:
        return  'Forty';
      default:
        return '';
    }
  }

}
