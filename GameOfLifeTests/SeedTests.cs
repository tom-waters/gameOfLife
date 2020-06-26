using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class SeedTests
    {
        [Fact]
        public void Given_StillLifeStartingSeeds_When_NextTickLiveCitiesAreFound_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var god = new God();
            var world = new World(god, 6, 6);
            var seeds = new List<(int, int)>()
            {
                (2,1),
                (3,1),
                (1,2),
                (4,2),
                (2,3),
                (3,3),
            };
            
            foreach (var seed in seeds)
            {
                god.AddSeed(world, seed.Item1, seed.Item2);
            }
            
            god.FindNextTickLiveCities(world);

            var expectedSeedCoordinates = god.NextTickLiveCities.Select(city => (city.Column, city.Row)).ToList();

            Assert.Equal(seeds, expectedSeedCoordinates);
        }
        
        [Fact]
        public void Given_OscillatorToadStartingSeeds_When_NextTickLiveCitiesAreFound_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var god = new God();
            var world = new World(god, 6, 6);
            var seeds = new List<(int, int)>()
            {
                (2,2),
                (3,2),
                (4,2),
                (1,3),
                (2,3),
                (3,3),
            };
            
            var expectedSeedCoordinates = new List<(int, int)>()
            {
                (3,1),
                (1,2),
                (4,2),
                (1,3),
                (4,3),
                (2,4)
            };
            
            foreach (var seed in seeds)
            {
                god.AddSeed(world, seed.Item1, seed.Item2);
            }
            
            god.FindNextTickLiveCities(world);

            var nextTickSeedCoordinates = god.NextTickLiveCities.Select(city => (city.Column, city.Row)).ToList();

            Assert.Equal(expectedSeedCoordinates, nextTickSeedCoordinates);
        }
        
        [Fact]
        public void Given_OscillatorBeaconStartingSeeds_When_NextTickLiveCitiesAreFound_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var god = new God();
            var world = new World(god, 6, 6);
            var seeds = new List<(int, int)>()
            {
                (1,1),
                (2,1),
                (1,2),
                (2,2),
                (3,3),
                (4,3),
                (3,4),
                (4,4),
            };
            
            var expectedSeedCoordinates = new List<(int, int)>()
            {
                (1,1),
                (2,1),
                (1,2),
                (4,3),
                (3,4),
                (4,4),
            };
            
            foreach (var seed in seeds)
            {
                god.AddSeed(world, seed.Item1, seed.Item2);
            }
            
            god.FindNextTickLiveCities(world);

            var nextTickSeedCoordinates = god.NextTickLiveCities.Select(city => (city.Column, city.Row)).ToList();

            Assert.Equal(expectedSeedCoordinates, nextTickSeedCoordinates);
        }

        [Fact]
        public void Given_OscillatorBeaconStartingSeeds_When_TwoTicksHaveElapsed_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var god = new God();
            var world = new World(god, 6, 6);
            var seeds = new List<(int, int)>()
            {
                (1,1),
                (2,1),
                (1,2),
                (2,2),
                (3,3),
                (4,3),
                (3,4),
                (4,4),
            };
            
            foreach (var seed in seeds)
            {
                god.AddSeed(world, seed.Item1, seed.Item2);
            }
            god.FindNextTickLiveCities(world);
            god.ApplyLifeRules(world);
            var nextTickSeeds = god.NextTickLiveCities;
            
            god.LiveCities.Clear();
            
            foreach (var seed in nextTickSeeds)
            {
                god.AddSeed(world, seed.Column, seed.Row);
            }
            
            god.FindNextTickLiveCities(world);
            god.ApplyLifeRules(world);


            var nextTickSeedCoordinates = god.NextTickLiveCities.Select(city => (city.Column, city.Row)).ToList();

            Assert.Equal(seeds, nextTickSeedCoordinates);
        }
        
    }
}