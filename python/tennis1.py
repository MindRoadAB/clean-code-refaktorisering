from enum import IntEnum


class Points(IntEnum):
    LOVE = 0
    FIFTEEN = 1
    THIRTY = 2
    FORTY = 3

    def pretty(self):
        return self.name.title()


class TennisGame1:
    def __init__(self, player1_name, player2_name):
        self.player1_name = player1_name
        self.player2_name = player2_name
        self.p1_points = Points.LOVE
        self.p2_points = Points.LOVE

    def won_point(self, player_name):
        if player_name == "player1":
            self.p1_points += 1
        else:
            self.p2_points += 1

    def score(self):
        result = ""
        match (self.p1_points, self.p2_points):
            case [p1, p2] if p1 == p2 and p1 < Points.FORTY:
                result = f"{Points(p1).pretty()}-All"
            case [p1, p2] if p1 == p2:
                result = "Deuce"
            case [p1, p2] if p1 <= Points.FORTY and p2 <= Points.FORTY:
                result = f"{Points(p1).pretty()}-{Points(p2).pretty()}"
            case [p1, p2] if p1 - p2 == 1:
                result = "Advantage player1"
            case [p1, p2] if p2 - p1 == 1:
                result = "Advantage player2"
            case [p1, p2] if p1 - p2 > 1:
                result = "Win for player1"
            case [p1, p2] if p2 - p1 > 1:
                result = "Win for player2"
        return result
