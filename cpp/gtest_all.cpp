//
// Created by Anders Arnholm on 2020-12-04.
//

#include <string>
#include <gtest/gtest.h>

const std::string tennisScore(int p1Score, int p2Score);

TEST(TennisTest, LoveAll_0_0) {
EXPECT_EQ("Love-All", tennisScore(0, 0));
}

TEST(TennisTest, FifteenAll_1_1) {
EXPECT_EQ("Fifteen-All", tennisScore(1, 1));
}

TEST(TennisTest, ThirtyAll_2_2) {
EXPECT_EQ("Thirty-All", tennisScore(2, 2));
}

TEST(TennisTest, Deuce_3_3) {
EXPECT_EQ("Deuce", tennisScore(3, 3));
}

TEST(TennisTest, Deuce_4_4) {
EXPECT_EQ("Deuce", tennisScore(4, 4));
}

TEST(TennisTest, FifteenLove_1_0) {
EXPECT_EQ("Fifteen-Love", tennisScore(1, 0));
}

TEST(TennisTest, LoveFifteen_0_1) {
EXPECT_EQ("Love-Fifteen", tennisScore(0, 1));
}

TEST(TennisTest, ThirtyLove_2_0) {
EXPECT_EQ("Thirty-Love", tennisScore(2, 0));
}

TEST(TennisTest, LoveThirty_0_2) {
EXPECT_EQ("Love-Thirty", tennisScore(0, 2));
}

TEST(TennisTest, FortyLove_3_0) {
EXPECT_EQ("Forty-Love", tennisScore(3, 0));
}

TEST(TennisTest, LoveForty_0_3) {
EXPECT_EQ("Love-Forty", tennisScore(0, 3));
}

TEST(TennisTest, Winforplayer1_4_0) {
EXPECT_EQ("Win for player1", tennisScore(4, 0));
}

TEST(TennisTest, Winforplayer2_0_4) {
EXPECT_EQ("Win for player2", tennisScore(0, 4));
}

TEST(TennisTest, ThirtyFifteen_2_1) {
EXPECT_EQ("Thirty-Fifteen", tennisScore(2, 1));
}

TEST(TennisTest, FifteenThirty_1_2) {
EXPECT_EQ("Fifteen-Thirty", tennisScore(1, 2));
}

TEST(TennisTest, FortyFifteen_3_1) {
EXPECT_EQ("Forty-Fifteen", tennisScore(3, 1));
}

TEST(TennisTest, FifteenForty_1_3) {
EXPECT_EQ("Fifteen-Forty", tennisScore(1, 3));
}

TEST(TennisTest, Winforplayer1_4_1) {
EXPECT_EQ("Win for player1", tennisScore(4, 1));
}

TEST(TennisTest, Winforplayer2_1_4) {
EXPECT_EQ("Win for player2", tennisScore(1, 4));
}

TEST(TennisTest, FortyThirty_3_2) {
EXPECT_EQ("Forty-Thirty", tennisScore(3, 2));
}

TEST(TennisTest, ThirtyForty_2_3) {
EXPECT_EQ("Thirty-Forty", tennisScore(2, 3));
}

TEST(TennisTest, Winforplayer1_4_2) {
EXPECT_EQ("Win for player1", tennisScore(4, 2));
}

TEST(TennisTest, Winforplayer2_2_4) {
EXPECT_EQ("Win for player2", tennisScore(2, 4));
}

TEST(TennisTest, Advantageplayer1_4_3) {
EXPECT_EQ("Advantage player1", tennisScore(4, 3));
}

TEST(TennisTest, Advantageplayer2_3_4) {
EXPECT_EQ("Advantage player2", tennisScore(3, 4));
}

TEST(TennisTest, Advantageplayer1_5_4) {
EXPECT_EQ("Advantage player1", tennisScore(5, 4));
}

TEST(TennisTest, Advantageplayer2_4_5) {
EXPECT_EQ("Advantage player2", tennisScore(4, 5));
}

TEST(TennisTest, Advantageplayer1_15_14) {
EXPECT_EQ("Advantage player1", tennisScore(15, 14));
}

TEST(TennisTest, Advantageplayer2_14_15) {
EXPECT_EQ("Advantage player2", tennisScore(14, 15));
}

TEST(TennisTest, Winforplayer1_6_4) {
EXPECT_EQ("Win for player1", tennisScore(6, 4));
}

TEST(TennisTest, Winforplayer2_4_6) {
EXPECT_EQ("Win for player2", tennisScore(4, 6));
}

TEST(TennisTest, Winforplayer1_16_14) {
EXPECT_EQ("Win for player1", tennisScore(16, 14));
}

TEST(TennisTest, Winforplayer2_14_16) {
EXPECT_EQ("Win for player2", tennisScore(14, 16));
}
