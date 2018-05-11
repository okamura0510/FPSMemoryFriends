#import <mach/mach.h>

extern "C" 
{
    unsigned int getUsedMemory() {
        struct task_basic_info info;
        mach_msg_type_number_t infoCount = TASK_BASIC_INFO_COUNT;
        kern_return_t status = task_info(current_task(), TASK_BASIC_INFO, (task_info_t)&info, &infoCount);
        
        if(status == KERN_SUCCESS) {
            return (unsigned int)info.resident_size;
        } else {
            return -1;
        }
    }
}