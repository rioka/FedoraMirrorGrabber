Improvements

> This is the list of repositories I'm using in my kickstart file.

```
url --mirrorlist="https://mirrors.fedoraproject.org/mirrorlist?repo=fedora-37&arch=x86_64"
repo --name=fedora-updates --mirrorlist="https://mirrors.fedoraproject.org/mirrorlist?repo=updates-released-f37&arch=x86_64" --cost=0
repo --name=rpmfusion-free --mirrorlist="https://mirrors.rpmfusion.org/mirrorlist?repo=free-fedora-37&arch=x86_64"
repo --name=rpmfusion-free-updates --mirrorlist="https://mirrors.rpmfusion.org/mirrorlist?repo=free-fedora-updates-released-37&arch=x86_64" --cost=0
repo --name=rpmfusion-nonfree --mirrorlist="https://mirrors.rpmfusion.org/mirrorlist?repo=nonfree-fedora-37&arch=x86_64"
repo --name=rpmfusion-nonfree-updates --mirrorlist="https://mirrors.rpmfusion.org/mirrorlist?repo=nonfree-fedora-updates-released-37&arch=x86_64" --cost=0
repo --name=google-chrome --install --baseurl="https://dl.google.com/linux/chrome/rpm/stable/x86_64" --cost=0
```

## Partial output from https://mirrors.fedoraproject.org/mirrorlist?repo=fedora-37&arch=x86_64 (releases)

```
# repo = fedora-37 arch = x86_64 country = SE country = IS country = FI country = MD country = BG country = UA country = SK country = RU country = DK country = DE country = LU country = FR country = CZ country = LT country = PT country = BE country = BY country = NL country = TR country = RS country = CH country = GB 
https://mirrors.xtom.de/fedora/releases/37/Everything/x86_64/os/
https://mirror.netsite.dk/fedora/linux/releases/37/Everything/x86_64/os/
http://mirror.in2p3.fr/pub/fedora/linux/releases/37/Everything/x86_64/os/
http://ftp.tudelft.nl/download.fedora.redhat.com/linux/releases/37/Everything/x86_64/os/
http://fedora.mirror.wearetriple.com/linux/releases/37/Everything/x86_64/os/
http://www.nic.funet.fi/pub/mirrors/fedora.redhat.com/pub/fedora/linux/releases/37/Everything/x86_64/os/
http://mirror.dogado.de/fedora/linux/releases/37/Everything/x86_64/os/
https://fedora.cu.be/linux/releases/37/Everything/x86_64/os/
https://ftp.plusline.net/fedora/linux/releases/37/Everything/x86_64/os/
http://ftp.byfly.by/pub/fedoraproject.org/linux/releases/37/Everything/x86_64/os/
http://mirror.23m.com/fedora/linux/releases/37/Everything/x86_64/os/
http://mirror.nl.leaseweb.net/fedora/linux/releases/37/Everything/x86_64/os/
http://ftp.fi.muni.cz/pub/linux/fedora/linux/releases/37/Everything/x86_64/os/
https://mirror.karneval.cz/pub/linux/fedora/linux/releases/37/Everything/x86_64/os/
http://fedora.ip-connect.info/linux/releases/37/Everything/x86_64/os/
https://mirror.init7.net/fedora/fedora/linux/releases/37/Everything/x86_64/os/
https://ftp.lysator.liu.se/pub/fedora/linux/releases/37/Everything/x86_64/os/
http://fedora.ip-connect.vn.ua/linux/releases/37/Everything/x86_64/os/
https://eu.edge.kernel.org/fedora/releases/37/Everything/x86_64/os/
http://ftp.halifax.rwth-aachen.de/fedora/linux/releases/37/Everything/x86_64/os/
```

## Partial output from https://mirrors.fedoraproject.org/mirrorlist?repo=updates-released-f37&arch=x86_64 (updates)

```
# repo = updates-released-f37 arch = x86_64 country = US country = CA 
https://ftp-nyc.osuosl.org/pub/fedora/linux/updates/37/Everything/x86_64/
http://mirrors.syringanetworks.net/fedora/linux/updates/37/Everything/x86_64/
http://mirror.sfo12.us.leaseweb.net/fedora/linux/updates/37/Everything/x86_64/
https://repos.eggycrew.com/fedora/updates/37/Everything/x86_64/
https://uvermont.mm.fcix.net/fedora/linux/updates/37/Everything/x86_64/
http://ziply.mm.fcix.net/fedora/linux/updates/37/Everything/x86_64/
http://opencolo.mm.fcix.net/fedora/linux/updates/37/Everything/x86_64/
https://mirrors.ocf.berkeley.edu/fedora/fedora/linux/updates/37/Everything/x86_64/
https://ftp-chi.osuosl.org/pub/fedora/linux/updates/37/Everything/x86_64/
http://forksystems.mm.fcix.net/fedora/linux/updates/37/Everything/x86_64/
http://veronanetworks.mm.fcix.net/fedora/linux/updates/37/Everything/x86_64/
http://mirror.math.princeton.edu/pub/fedora/linux/updates/37/Everything/x86_64/
https://mirror.umd.edu/fedora/linux/updates/37/Everything/x86_64/
https://ix-denver.mm.fcix.net/fedora/linux/updates/37/Everything/x86_64/
https://ohioix.mm.fcix.net/fedora/linux/updates/37/Everything/x86_64/
https://nocix.mm.fcix.net/fedora/linux/updates/37/Everything/x86_64/
http://mirror.arizona.edu/fedora/linux/updates/37/Everything/x86_64/
https://nnenix.mm.fcix.net/fedora/linux/updates/37/Everything/x86_64/
http://mirror.fcix.net/fedora/linux/updates/37/Everything/x86_64/
https://mirrors.rit.edu/fedora/fedora/linux/updates/37/Everything/x86_64/
```

## Partial output from https://mirrors.fedoraproject.org/metalink?repo=fedora-37&arch=x86_64

```xml
    <url protocol="http" type="http" location="DE" preference="100">http://mirror.23m.com/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml</url>
    <url protocol="https" type="https" location="DE" preference="100">https://mirror.23m.com/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml</url>
    <url protocol="rsync" type="rsync" location="DE" preference="100">rsync://mirror.23m.com/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml</url>
```

It looks like `http://mirror.23m.com/fedora/linux/updates/37/Everything/` could be used, and should be added to my list, too.

## Output from https://mirrors.rpmfusion.org/mirrorlist?repo=free-fedora-37&arch=x86_64  (rpmfusion-free)

```
# repo = free-fedora-37 arch = x86_64 country = US country = CA 
http://mirror.fcix.net/rpmfusion/free/fedora/releases/37/Everything/x86_64/os/
http://mirrors.ocf.berkeley.edu/rpmfusion/free/fedora/releases/37/Everything/x86_64/os/
http://mirror.math.princeton.edu/pub/rpmfusion/free/fedora/releases/37/Everything/x86_64/os/
http://muug.ca/mirror/rpmfusion/free/fedora/releases/37/Everything/x86_64/os/
http://mirror.dst.ca/rpmfusion/free/fedora/releases/37/Everything/x86_64/os/
```

## Output from https://mirrors.rpmfusion.org/mirrorlist?repo=free-fedora-updates-released-37&arch=x86_64 (rpmfusion-free-updates)

```
# repo = free-fedora-updates-released-37 arch = x86_64 country = US country = CA 
http://mirror.fcix.net/rpmfusion/free/fedora/updates/37/x86_64/
http://mirror.math.princeton.edu/pub/rpmfusion/free/fedora/updates/37/x86_64/
http://mirrors.ocf.berkeley.edu/rpmfusion/free/fedora/updates/37/x86_64/
http://muug.ca/mirror/rpmfusion/free/fedora/updates/37/x86_64/
http://mirror.dst.ca/rpmfusion/free/fedora/updates/37/x86_64/
```

I can query https://mirrors.rpmfusion.org/metalink?repo=free-fedora-updates-released-37&arch=x86_64, too, and I get 

```xml
    <url protocol="http" type="http" location="US" preference="100">http://mirror.fcix.net/rpmfusion/free/fedora/updates/37/x86_64/repodata/repomd.xml</url>
    <url protocol="https" type="https" location="US" preference="100">https://mirror.fcix.net/rpmfusion/free/fedora/updates/37/x86_64/repodata/repomd.xml</url>
    <url protocol="rsync" type="rsync" location="US" preference="100">rsync://mirror.fcix.net/rpmfusion/free/fedora/updates/37/x86_64/repodata/repomd.xml</url>
    <url protocol="http" type="http" location="US" preference="99">http://mirror.math.princeton.edu/pub/rpmfusion/free/fedora/updates/37/x86_64/repodata/repomd.xml</url>
    <url protocol="rsync" type="rsync" location="US" preference="99">rsync://mirror.math.princeton.edu/pub/rpmfusion/free/fedora/updates/37/x86_64/repodata/repomd.xml</url>
```

# Output from https://mirrors.rpmfusion.org/mirrorlist?repo=nonfree-fedora-37&arch=x86_64 (rpmfusion-nonfree)

```
# repo = nonfree-fedora-37 arch = x86_64 country = US country = CA 
http://ziply.mm.fcix.net/rpmfusion/nonfree/fedora/releases/37/Everything/x86_64/os/
http://mirror.math.princeton.edu/pub/rpmfusion/nonfree/fedora/releases/37/Everything/x86_64/os/
https://forksystems.mm.fcix.net/rpmfusion/nonfree/fedora/releases/37/Everything/x86_64/os/
https://uvermont.mm.fcix.net/rpmfusion/nonfree/fedora/releases/37/Everything/x86_64/os/
http://southfront.mm.fcix.net/rpmfusion/nonfree/fedora/releases/37/Everything/x86_64/os/
https://mirror.fcix.net/rpmfusion/nonfree/fedora/releases/37/Everything/x86_64/os/
http://mirrors.ocf.berkeley.edu/rpmfusion/nonfree/fedora/releases/37/Everything/x86_64/os/
http://opencolo.mm.fcix.net/rpmfusion/nonfree/fedora/releases/37/Everything/x86_64/os/
http://ohioix.mm.fcix.net/rpmfusion/nonfree/fedora/releases/37/Everything/x86_64/os/
http://muug.ca/mirror/rpmfusion/nonfree/fedora/releases/37/Everything/x86_64/os/
http://mirror.dst.ca/rpmfusion/nonfree/fedora/releases/37/Everything/x86_64/os/
```

# Output from https://mirrors.rpmfusion.org/mirrorlist?repo=nonfree-fedora-updates-released-37&arch=x86_64 (rpmfusion-nonfree-updates)

```
# repo = nonfree-fedora-updates-released-37 arch = x86_64 country = US country = CA 
http://mirrors.ocf.berkeley.edu/rpmfusion/nonfree/fedora/updates/37/x86_64/
https://forksystems.mm.fcix.net/rpmfusion/nonfree/fedora/updates/37/x86_64/
http://ohioix.mm.fcix.net/rpmfusion/nonfree/fedora/updates/37/x86_64/
http://mirror.math.princeton.edu/pub/rpmfusion/nonfree/fedora/updates/37/x86_64/
http://ziply.mm.fcix.net/rpmfusion/nonfree/fedora/updates/37/x86_64/
https://mirror.fcix.net/rpmfusion/nonfree/fedora/updates/37/x86_64/
https://uvermont.mm.fcix.net/rpmfusion/nonfree/fedora/updates/37/x86_64/
http://southfront.mm.fcix.net/rpmfusion/nonfree/fedora/updates/37/x86_64/
http://opencolo.mm.fcix.net/rpmfusion/nonfree/fedora/updates/37/x86_64/
http://muug.ca/mirror/rpmfusion/nonfree/fedora/updates/37/x86_64/
http://mirror.dst.ca/rpmfusion/nonfree/fedora/updates/37/x86_64/
```