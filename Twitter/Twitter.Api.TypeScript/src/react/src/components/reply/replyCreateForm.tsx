import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ReplyMapper from './replyMapper';
import ReplyViewModel from './replyViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { UserSelectComponent } from '../shared/userSelect'
	
interface ReplyCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface ReplyCreateComponentState {
  model?: ReplyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class ReplyCreateComponent extends React.Component<
  ReplyCreateComponentProps,
  ReplyCreateComponentState
> {
  state = {
    model: new ReplyViewModel(),
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
        let model = values as ReplyViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:ReplyViewModel) =>
  {  
    let mapper = new ReplyMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Replies,
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
            Api.ReplyClientRequestModel
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
              <label htmlFor='content'>content</label>
              <br />             
              {getFieldDecorator('content', {
              rules:[{ required: true, message: 'Required' },
{ max: 140, message: 'Exceeds max length of 140' },
],
              
              })
              ( <Input placeholder={"content"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='date'>date</label>
              <br />             
              {getFieldDecorator('date', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='replierUserId'>replier_user_id</label>
              <br />             
              {getFieldDecorator('replierUserId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"replier_user_id"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='time'>time</label>
              <br />             
              {getFieldDecorator('time', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"time"} /> )}
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

export const WrappedReplyCreateComponent = Form.create({ name: 'Reply Create' })(ReplyCreateComponent);

/*<Codenesium>
    <Hash>2bb54a51e16ff6c5ae4308d3ca96ebdb</Hash>
</Codenesium>*/