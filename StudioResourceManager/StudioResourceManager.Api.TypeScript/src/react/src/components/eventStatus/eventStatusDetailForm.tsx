import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EventStatusMapper from './eventStatusMapper';
import EventStatusViewModel from './eventStatusViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { EventTableComponent } from '../shared/eventTable';

interface EventStatusDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EventStatusDetailComponentState {
  model?: EventStatusViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class EventStatusDetailComponent extends React.Component<
  EventStatusDetailComponentProps,
  EventStatusDetailComponentState
> {
  state = {
    model: new EventStatusViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.EventStatus + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.EventStatus +
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
          let response = resp.data as Api.EventStatusClientResponseModel;

          console.log(response);

          let mapper = new EventStatusMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Events</h3>
            <EventTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.EventStatus +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Events
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedEventStatusDetailComponent = Form.create({
  name: 'EventStatus Detail',
})(EventStatusDetailComponent);


/*<Codenesium>
    <Hash>934da6a80010486effb6fabeb28efe88</Hash>
</Codenesium>*/