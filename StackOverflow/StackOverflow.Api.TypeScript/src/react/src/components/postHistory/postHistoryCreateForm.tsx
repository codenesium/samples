import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryMapper from './postHistoryMapper';
import PostHistoryViewModel from './postHistoryViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';

interface PostHistoryCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface PostHistoryCreateComponentState {
  model?: PostHistoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class PostHistoryCreateComponent extends React.Component<
  PostHistoryCreateComponentProps,
  PostHistoryCreateComponentState
> {
  state = {
    model: new PostHistoryViewModel(),
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
        let model = values as PostHistoryViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:PostHistoryViewModel) =>
  {  
    let mapper = new PostHistoryMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PostHistories,
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
            Api.PostHistoryClientRequestModel
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
              <label htmlFor='comment'>Comment</label>
              <br />             
              {getFieldDecorator('comment', {
              rules:[{ max: 1073741823, message: 'Exceeds max length of 1073741823' },
],
              
              })
              ( <Input placeholder={"Comment"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='creationDate'>CreationDate</label>
              <br />             
              {getFieldDecorator('creationDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"CreationDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='postHistoryTypeId'>PostHistoryTypeId</label>
              <br />             
              {getFieldDecorator('postHistoryTypeId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"PostHistoryTypeId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='postId'>PostId</label>
              <br />             
              {getFieldDecorator('postId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"PostId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='revisionGUID'>RevisionGUID</label>
              <br />             
              {getFieldDecorator('revisionGUID', {
              rules:[{ required: true, message: 'Required' },
{ max: 36, message: 'Exceeds max length of 36' },
],
              
              })
              ( <Input placeholder={"RevisionGUID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='text'>Text</label>
              <br />             
              {getFieldDecorator('text', {
              rules:[{ max: 1073741823, message: 'Exceeds max length of 1073741823' },
],
              
              })
              ( <Input placeholder={"Text"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='userDisplayName'>UserDisplayName</label>
              <br />             
              {getFieldDecorator('userDisplayName', {
              rules:[{ max: 40, message: 'Exceeds max length of 40' },
],
              
              })
              ( <Input placeholder={"UserDisplayName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='userId'>UserId</label>
              <br />             
              {getFieldDecorator('userId', {
              rules:[],
              
              })
              ( <Input placeholder={"UserId"} /> )}
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

export const WrappedPostHistoryCreateComponent = Form.create({ name: 'PostHistory Create' })(PostHistoryCreateComponent);

/*<Codenesium>
    <Hash>42154aef29dda5ad9eced26afc34c712</Hash>
</Codenesium>*/