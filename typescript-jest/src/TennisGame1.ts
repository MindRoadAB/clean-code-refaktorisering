import { TennisGame } from './TennisGame';

interface Player {
  name: string;
  score: number;
}

export class TennisGame1 implements TennisGame {
  private players: { [id: string]: number } =  {}

  constructor(player1Name: string, player2Name: string) {
    this.players[player1Name] = 0;
    this.players[player2Name] = 0;
  }

  wonPoint(playerName: string): void {
    this.players[playerName] += 1;
  }

  getScore(): string {
    let score: string = '';
    let tempScore: number = 0;
    if (this.m_score1 === this.m_score2) {
      switch (this.m_score1) {
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
    }
    else if (this.m_score1 >= 4 || this.m_score2 >= 4) {
      const minusResult: number = this.m_score1 - this.m_score2;
      if (minusResult === 1) score = 'Advantage player1';
      else if (minusResult === -1) score = 'Advantage player2';
      else if (minusResult >= 2) score = 'Win for player1';
      else score = 'Win for player2';
    }
    else {
      for (let i = 1; i < 3; i++) {
        if (i === 1) tempScore = this.m_score1;
        else { score += '-'; tempScore = this.m_score2; }
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
}
