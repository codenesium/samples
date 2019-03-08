import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CommentsMapper from './commentsMapper';
import CommentsViewModel from './commentsViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { PostsSelectComponent } from '../shared/postsSelect'
	import { UsersSelectComponent } from '../shared/usersSelect'
	
interface CommentsCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface CommentsCreateComponentState {
  model?: CommentsViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class CommentsCreateComponent extends React.Component<
  CommentsCreateComponentProps,
  CommentsCreateComponentState
> {
  state = {
    model: new CommentsViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false,
	submitting:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
	 this.setState({...this.state, submitting:true, submitted:false});
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as CommentsViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:CommentsViewModel) =>
  {  
    let mapper = new CommentsMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Comments,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.CommentsClientRequestModel
          >;
          this.setState({...this.state, submitted:true, submitting:false, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          if(error.response.data)
          {
			  let errorResponse = error.response.data as ActionResponse; 

			  errorResponse.validationErrors.forEach(x =>
			  {
				this.props.form.setFields({
				 [ToLowerCaseFirstLetter(x.propertyName)]: {
				  value:this.props.form.getFieldValue(ToLowerCaseFirstLetter(x.propertyName)),
				  errors: [new Error(x.errorMessage)]
				},
				})
			  });
		  }
          this.setState({...this.state, submitted:true, submitting:false, errorOccurred:true, errorMessage:'Error from API'});
        }
      ); 
  }
  
  render() {

    const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        
    let message:JSX.Element = <div></div>;
    if(this.state.submitted)
    {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type='error' />;
      }
      else
      {
        message = <Alert message='Submitted' type='success' />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='creationDate'>Creation Date</label>
              <br />             
              {getFieldDecorator('creationDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Creation Date"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='postId'>Post</label>
                        <br />   
                        <PostsSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Posts}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="postId"
                          required={true}
                          selectedValue={this.state.model!.postId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='score'>Score</label>
              <br />             
              {getFieldDecorator('score', {
              rules:[],
              
              })
              ( <Input placeholder={"Score"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='text'>Text</label>
              <br />             
              {getFieldDecorator('text', {
              rules:[{ required: true, message: 'Required' },
{ max: 700, message: 'Exceeds max length of 700' },
],
              
              })
              ( <Input placeholder={"Text"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='userId'>User</label>
                        <br />   
                        <UsersSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Users}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="userId"
                          required={false}
                          selectedValue={this.state.model!.userId}
                         />
                        </Form.Item>

			
           <Form.Item>
            <Button type="primary" htmlType="submit" loading={this.state.submitting} >
                {(this.state.submitting ? "Submitting..." : "Submit")}
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedCommentsCreateComponent = Form.create({ name: 'Comments Create' })(CommentsCreateComponent);

/*<Codenesium>
    <Hash>ad7f935689526e55b599188466309af5</Hash>
</Codenesium>*/