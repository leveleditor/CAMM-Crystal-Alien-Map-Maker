Dumped using JavaScript by https://github.com/Brian151
(AKA 'ETXAlienRobot201' / 'ETX' on http://marsmissionwiki.wikifoundry.com)

The data in these files may not be 100% accurate. 
This is mainly due to discrepencies in the CAMM format and CAC's level data.

Astro Level 5 uses a main base whose type and team depends on the player's current team,
the dump does not reflect that.

The Santa bonus level uses teams set according to the current opponent

The Alien special ops uses a randomizer to set the obj paramater of about five units,
I'm not sure why, but the export does not reflect this.

Astro Special Ops 3 uses a randomizer to choose the spawn positon of
the present with the alien commander. This is not reflected, a single path was
chosen.

Some levels override the construction options, this is not reflected in these dumps, either.

Most levels clear some area of the 'shroud' , CAC's fog of war, CAMM doesn't yet support this.
The dumps also are missing that.

Most levels are packed with indicators and re-focus the camera.
This data is also not present.

There also were cases due to CAMM being otherwise unable to read the data that has reaulted
in null having to be given a default value. That said, the AI target parameter of units
is to be assumed always wrong in these dumps.

update:
level27 repaired, i didn't change a 96 to a 48 in a 'rejig' function, whoops!
