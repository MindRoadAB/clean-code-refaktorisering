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

    def won_point_player1(self):
        self.p1_points += 1

    def won_point_player2(self):
        self.p2_points += 1

    def score(self):
        result = ""
        match (self.p1_points, self.p2_points):
            case [p1, p2] if p1 == p2 and p1 < Points.FORTY:
                # Even points, below forty
                result = f"{Points(p1).pretty()}-All"
            case [p1, p2] if p1 == p2:
                # Even points, forty or above
                result = "Deuce"
            case [p1, p2] if p1 <= Points.FORTY and p2 <= Points.FORTY:
                # Different points, both below forty
                result = f"{Points(p1).pretty()}-{Points(p2).pretty()}"
            case [p1, p2] if p1 - p2 == 1:
                # One ball difference, above forty, player 1 advantage
                result = f"Advantage {self.player1_name}"
            case [p1, p2] if p2 - p1 == 1:
                # One ball difference, above forty, player 2 advantage
                result = f"Advantage {self.player2_name}"
            case [p1, p2] if p1 - p2 > 1:
                # More than one ball difference, player 1 above forty
                result = f"Win for {self.player1_name}"
            case [p1, p2] if p2 - p1 > 1:
                # More than one ball difference, player 2 above forty
                result = f"Win for {self.player2_name}"
        return result
