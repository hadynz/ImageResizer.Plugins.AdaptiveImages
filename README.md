# ImageResizer.Plugins.AdaptiveImages

Make your website images truly responsive as well!

## About AdaptiveImages
Adaptive Images detects your visitor's screen size and automatically creates and delivers device 
appropriate re-scaled versions of your web page's embeded HTML images. No mark-up changes needed.
It is intended for use with Responsive Designs and to be combined with Fluid Image techniques.

Why? Because your site is being increasingly viewed on smaller, slower, low bandwidth devices. 
On those devices your desktop-centric images load slowly, cause UI lag, and cost you and your 
visitors un-necessary bandwidth and money. Adaptive Images fixes that.

This library is a port of the original PHP solution that was authored by Matt Wilcox. Original
solution is documented and detailed here: http://adaptive-images.com

### Building on top of ImageResizer

### Key Benefits

## Source Code and Downloads

## Configuration
Copy the following Javascript into the ```<head>``` of your site. It MUST go in the head as the first 
bit of JS, before any other JS. This is because it needs to work as soon as possible, any delay 
wil have adverse effects.

 ```javascript
<script>document.cookie='resolution='+Math.max(screen.width,screen.height)+'; path=/';</script>
```

## How it works
1. If the above JavaScript snippet is inserted in a page, a cookie will be inserted with a 
dimension of the greater of the width or the height of the current device. All images greater
in width than the size of the cookie dimension will automatically be scaled down.

2. If a cookie not set, mobile devices will be supplied with the smallest image that matches
the smallest breakpoint resolution configuration - which is currently set to 480px and cannot
be customised.

3. All image resizing is handled OOB by ImageResizer (http://imageresizing.net/).
