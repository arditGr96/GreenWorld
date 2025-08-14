document.addEventListener("DOMContentLoaded", function () {

    let contentCount = 1; 
    let imageCount = 1;  

    const dynamicContainer = document.getElementById('dynamicFields');
    const addContentBtn = document.getElementById('addContent');
    const addImageBtn = document.getElementById('addImage');

    if (addContentBtn && dynamicContainer) {
        addContentBtn.addEventListener('click', function () {
            if (contentCount >= 4) {
                alert("Maximum 4 content fields allowed.");
                return;
            }
            contentCount++;
            const div = document.createElement('div');
            div.className = 'mb-3';
            div.innerHTML = `
                <label class="form-label">Content ${contentCount}</label>
                <textarea name="Content${contentCount}" class="form-control"></textarea>
            `;
            dynamicContainer.appendChild(div);
        });
    }

    if (addImageBtn && dynamicContainer) {
        addImageBtn.addEventListener('click', function () {
            if (imageCount >= 3) {
                alert("Maximum 3 images allowed.");
                return;
            }
            imageCount++;
            const div = document.createElement('div');
            div.className = 'mb-3';
            div.innerHTML = `
                <label class="form-label">Image ${imageCount}</label>
                <input type="file" name="imageFile${imageCount}" class="form-control" />
            `;
            dynamicContainer.appendChild(div);
        });
    }



    function createParticle() {
        const particle = document.createElement('div');
        particle.className = 'particle';
        particle.style.left = Math.random() * 100 + '%';
        particle.style.width = particle.style.height = Math.random() * 4 + 2 + 'px';
        particle.style.animationDuration = (Math.random() * 10 + 10) + 's';
        particle.style.animationDelay = Math.random() * 2 + 's';

      
        setTimeout(() => {
            particle.remove();
        }, 20000);
    }

    // Generate particles periodically
    setInterval(createParticle, 2000);

    // Initial particles
    for (let i = 0; i < 10; i++) {
        setTimeout(createParticle, i * 200);
    }

    // Parallax effect on scroll
    window.addEventListener('scroll', () => {
        const scrolled = window.pageYOffset;
        const parallaxElements = document.querySelectorAll('.floating-eco-element');

        parallaxElements.forEach((element, index) => {
            const speed = (index + 1) * 0.1;
            element.style.transform = `translateY(${scrolled * speed}px)`;
        });
    });
});
