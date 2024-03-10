use crate::TennisGame;

#[derive(Default)]
pub struct TennisGame1 {
    score_player1: u8,
    score_player2: u8,
}

impl TennisGame1 {
    pub fn new() -> Self {
        Self {
            score_player1: 0,
            score_player2: 0,
        }
    }
	
	pub fn score_to_string(score: u8) -> &'static str {
		match score {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => ""
		}
	}
}

impl TennisGame for TennisGame1 {
    fn clear(&mut self) {
        self.score_player1 = 0;
        self.score_player2 = 0;
    }

    fn won_point(&mut self, player_name: &str) {
        if player_name == "player1" {
            self.score_player1 += 1;
        } else {
            self.score_player2 += 1;
        }
    }

    fn get_score(&self) -> String {
        let mut current_score = String::new();
		if self.score_player1 == self.score_player2 {
			match self.score_player1 {
                0 => current_score.push_str("Love-All"),
                1 => current_score.push_str("Fifteen-All"),
                2 => current_score.push_str("Thirty-All"),
                _ => current_score.push_str("Deuce"),
            }
		} else if (self.score_player1 >= 4) || (self.score_player2 >= 4) {
			let score_difference = self.score_player1 as i8 - self.score_player2 as i8;
			match score_difference {
				s if s <= -2 => current_score.push_str("Win for player2"),
				-1 => current_score.push_str("Advantage player2"),
				 1 => current_score.push_str("Advantage player1"),
				s if s >= 2 => current_score.push_str("Win for player1"),
				_ => {}
			}
		} else {
			current_score.push_str(TennisGame1::score_to_string(self.score_player1));
			current_score.push_str("-");
			current_score.push_str(TennisGame1::score_to_string(self.score_player2));
        }
		return current_score;
    }
}
