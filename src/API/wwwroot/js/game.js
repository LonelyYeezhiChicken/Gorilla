// 創建遊戲配置
var config = {
    type: Phaser.AUTO,
    width: 900,
    height: 430,
    parent: "game",
    scene: {
        preload: preload,
        create: create,
        update: update
    }
};

// 創建遊戲實例
var game = new Phaser.Game(config);

let gorilla;
function preload() {
    this.load.image('background', '/assets/background.webp');
    this.load.spritesheet('gorilla', '/assets/gorilla.png', { frameWidth: 132, frameHeight: 102 });
}

function create() {
    this.add.image(0, 0, 'background').setOrigin(0, 0);

    // 添加gorilla sprite
    gorilla = this.add.sprite(0, 340, 'gorilla');
    gorilla.setOrigin(0, 0);


    this.anims.create({
        key: 'gorillaAnimation',
        frames: this.anims.generateFrameNumbers('gorilla', { start: 0, end: 3 }),
        frameRate: 10,
        repeat: -1
    });

    // 播放gorilla
    gorilla.play('gorillaAnimation');
}

let speed = 1;
function update() {

    //轉向
    if (gorilla.x >= 850) {
        gorilla.flipX = true;
        speed = -1;
    } else if (gorilla.x <= 50) {
        gorilla.flipX = false;
        speed = 1;
    }

    gorilla.x += speed;
}