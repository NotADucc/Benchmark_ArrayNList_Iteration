﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerkoopTruithesBL.Exceptions;

namespace VerkoopTruithesBL.Model {
    public class Truitje {
        public Truitje(int id, double prijs, string seizoen, Club club, ClubSet clubSet, KledingMaat kledingMaat) : this(prijs, seizoen, club, clubSet, kledingMaat) {
            ZetId(id);
        }
        public Truitje(double prijs, string seizoen, Club club, ClubSet clubSet, KledingMaat kledingMaat) {
            ZetPrijs(prijs);
            ZetSeizoen(seizoen);
            ZetClub(club);
            ZetClubSet(clubSet);
            KledingMaat = kledingMaat;
        }
        public double Prijs { get; private set; }
        public int Id { get; private set; }
        public string Seizoen { get; private set; }
        public Club Club { get; private set; }
        public ClubSet ClubSet { get; private set; }
        public KledingMaat KledingMaat { get; set; }
        public void ZetPrijs(double prijs) {
            if (prijs < 0) throw new TruitjeException("ZetPrijs");
            Prijs = prijs;
        }
        public void ZetId(int id) {
            if (id <= 0) throw new TruitjeException("ZetId");
            Id = id;
        }
        public void ZetSeizoen(string seizoen) {
            if (string.IsNullOrWhiteSpace(seizoen)) throw new TruitjeException("ZetSeizoen");
            Seizoen = seizoen;
        }
        public void ZetClub(Club club) {
            if (club == null) throw new TruitjeException("ZetClub");
            Club = club;
        }
        public void ZetClubSet(ClubSet clubSet) {
            if (clubSet == null) throw new TruitjeException("ZetClubSet");
            ClubSet = clubSet;
        }
        public override bool Equals(object? obj) {
            return obj is Truitje truitje &&
                   Id == truitje.Id;
        }
        public override int GetHashCode() {
            return HashCode.Combine(Id);
        }

        public override string? ToString() {
            return $"{Id}: {Club} {ClubSet} Seizoen: {Seizoen} Maat: {KledingMaat} Prijs: {Prijs}";
        }
    }
}
