import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import QuoteTweetMapper from './quoteTweetMapper';
import QuoteTweetViewModel from './quoteTweetViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface QuoteTweetEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface QuoteTweetEditComponentState {
  model?: QuoteTweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class QuoteTweetEditComponent extends React.Component<
  QuoteTweetEditComponentProps,
  QuoteTweetEditComponentState
> {
  state = {
    model: new QuoteTweetViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

    componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.QuoteTweets +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.QuoteTweetClientResponseModel;

          console.log(response);

          let mapper = new QuoteTweetMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

		  this.props.form.setFieldsValue(mapper.mapApiResponseToViewModel(response));
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
 }
 
 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as QuoteTweetViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:QuoteTweetViewModel) =>
  {  
    let mapper = new QuoteTweetMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.QuoteTweets + '/' + this.state.model!.quoteTweetId,
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
            Api.QuoteTweetClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          this.setState({...this.state, submitted:true, errorOccurred:true, errorMessage:'Error from API'});
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
              <label htmlFor='retweeterUserId'>retweeter_user_id</label>
              <br />             
              {getFieldDecorator('retweeterUserId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"retweeter_user_id"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='sourceTweetId'>source_tweet_id</label>
              <br />             
              {getFieldDecorator('sourceTweetId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"source_tweet_id"} /> )}
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
            <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedQuoteTweetEditComponent = Form.create({ name: 'QuoteTweet Edit' })(QuoteTweetEditComponent);

/*<Codenesium>
    <Hash>a3a4f27a8822601b84158a51c2157c63</Hash>
</Codenesium>*/